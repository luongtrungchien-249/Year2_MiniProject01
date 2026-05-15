using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StrokePrediction.Core.entities;
using StrokePrediction.Core.interfaces;
using StrokePrediction.Infrastructure.config;

namespace StrokePrediction.Infrastructure.externalapi;

/// <summary>
/// Gọi Python subprocess hoặc HTTP API (Ngrok) để chạy ML model
/// </summary>
public class PythonMLBridgeService : IMLModelService
{
    private readonly PythonSettings _settings;
    private readonly ModelSettings _modelSettings;
    private readonly ILogger<PythonMLBridgeService> _logger;
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions _json = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public PythonMLBridgeService(
        IOptions<AppSettings> opts,
        ILogger<PythonMLBridgeService> logger)
    {
        _settings      = opts.Value.Python;
        _modelSettings = opts.Value.Models;
        _logger        = logger;
        _httpClient    = new HttpClient { Timeout = TimeSpan.FromMilliseconds(_settings.TimeoutMs) };
    }

    public bool IsModelLoaded(string modelName)
        => _modelSettings.AvailableModels.Contains(modelName);

    public Task<IEnumerable<string>> GetAvailableModelsAsync(CancellationToken ct = default)
        => Task.FromResult<IEnumerable<string>>(_modelSettings.AvailableModels);

    public async Task<PredictionResult> PredictAsync(
        PatientInput input,
        string modelName = "stacking",
        double? threshold = null,
        CancellationToken ct = default)
    {
        if (!IsModelLoaded(modelName))
            throw new ArgumentException($"Model '{modelName}' không tồn tại.", nameof(modelName));

        var payload = new
        {
            model_name = modelName,
            threshold = threshold,
            input = new
            {
                gender            = input.Gender,
                age               = input.Age,
                hypertension      = input.Hypertension,
                heart_disease     = input.HeartDisease,
                ever_married      = input.EverMarried,
                work_type         = input.WorkType,
                Residence_type    = input.ResidenceType,
                avg_glucose_level = input.AvgGlucoseLevel,
                bmi               = input.Bmi,
                smoking_status    = input.SmokingStatus
            }
        };

        var payloadJson = JsonSerializer.Serialize(payload);
        _logger.LogDebug("Calling Python: {Payload}", payloadJson);
        string responseJson = string.Empty;

        // Nếu có cấu hình Ngrok -> Gọi qua API
        if (!string.IsNullOrWhiteSpace(_settings.NgrokUrl))
        {
            var url = _settings.NgrokUrl.TrimEnd('/') + "/predict";
            var content = new StringContent(payloadJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content, ct);
            responseJson = await response.Content.ReadAsStringAsync(ct);
            
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Ngrok API failed with status {Status}: {Body}", response.StatusCode, responseJson);
                try {
                    var errDoc = JsonDocument.Parse(responseJson);
                    if (errDoc.RootElement.TryGetProperty("error", out var errProp))
                        throw new InvalidOperationException($"AI Service Error: {errProp.GetString()}");
                } catch (JsonException) { }
                throw new InvalidOperationException($"AI Service unreachable or failed (HTTP {response.StatusCode})");
            }
        }
        else
        {
            // Fallback chạy subprocess Local
            // Resolve đường dẫn script tuyệt đối từ ContentRoot
            var contentRoot = AppDomain.CurrentDomain.BaseDirectory;
            // Khi chạy `dotnet run`, BaseDirectory trỏ vào bin/Debug/...
            // ScriptPath = "scripts/predict.py" nằm trong source project
            var scriptAbsPath = Path.GetFullPath(
                Path.Combine(contentRoot, "..", "..", "..", _settings.ScriptPath));
            
            if (!File.Exists(scriptAbsPath))
            {
                // Fallback: thử từ current directory
                scriptAbsPath = Path.GetFullPath(_settings.ScriptPath);
            }

            _logger.LogInformation("Python script path: {Path} | Exists: {Exists}", scriptAbsPath, File.Exists(scriptAbsPath));

            // Tạo file tạm để chứa payload (tránh lỗi Encoding qua Standard Input trên Windows)
            var tempFile = Path.GetTempFileName();
            await File.WriteAllTextAsync(tempFile, payloadJson, Encoding.UTF8, ct);

            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName               = _settings.PythonExePath,
                    Arguments              = $"\"{scriptAbsPath}\" \"{tempFile}\"",
                    WorkingDirectory       = Path.GetDirectoryName(scriptAbsPath) ?? ".",
                    UseShellExecute        = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError  = true,
                    StandardOutputEncoding = Encoding.UTF8,
                    CreateNoWindow         = true
                }
            };

            process.Start();

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(_settings.TimeoutMs);

            var outputTask = process.StandardOutput.ReadToEndAsync(cts.Token);
            var errorTask  = process.StandardError.ReadToEndAsync(cts.Token);

            await Task.WhenAll(outputTask, errorTask);
            await process.WaitForExitAsync(cts.Token);

            responseJson = await outputTask;
            var stderr = await errorTask;

            _logger.LogInformation("Python exit={ExitCode} | stdout={StdOut} | stderr={StdErr}",
                process.ExitCode,
                string.IsNullOrWhiteSpace(responseJson) ? "(empty)" : responseJson.Trim(),
                string.IsNullOrWhiteSpace(stderr) ? "(empty)" : stderr.Trim());

            if (process.ExitCode != 0)
                throw new InvalidOperationException($"Python script failed (exit {process.ExitCode}): {stderr}");

            // Xóa file tạm
            try { if (File.Exists(tempFile)) File.Delete(tempFile); } catch { }
        }

        // Parse JSON output
        var pyResult = JsonSerializer.Deserialize<PythonPredictResponse>(responseJson, _json)
                       ?? throw new InvalidOperationException("Python trả về JSON rỗng.");

        if (pyResult.Error is not null)
            throw new InvalidOperationException($"Python error: {pyResult.Error}");

        return new PredictionResult
        {
            Prediction  = pyResult.Prediction,
            Probability = pyResult.Probability,
            RiskLevel   = pyResult.RiskLevel,
            Message     = pyResult.Message,
            ModelUsed   = pyResult.ModelUsed,
            PredictedAt = DateTime.UtcNow
        };
    }

    private sealed class PythonPredictResponse
    {
        public int Prediction { get; set; }
        public double Probability { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string ModelUsed { get; set; } = string.Empty;
        public string? Error { get; set; }
    }
}
