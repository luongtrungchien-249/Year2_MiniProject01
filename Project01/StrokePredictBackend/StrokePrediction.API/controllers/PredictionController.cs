using Microsoft.AspNetCore.Mvc;
using StrokePrediction.API.dtos;
using StrokePrediction.Core.entities;
using StrokePrediction.Core.interfaces;
using StrokePrediction.Core.usecases;

namespace StrokePrediction.API.controllers;

/// <summary>
/// Controller: Dự đoán đột quỵ
/// Route: /api/v1/predictions
/// </summary>
[ApiController]
[Route("api/v1/predictions")]
[Produces("application/json")]
public class PredictionController : ControllerBase
{
    private readonly PredictStrokeUseCase _predictUseCase;
    private readonly GetPredictionHistoryUseCase _historyUseCase;
    private readonly IMLModelService _mlService;
    private readonly ILogger<PredictionController> _logger;

    public PredictionController(
        PredictStrokeUseCase predictUseCase,
        GetPredictionHistoryUseCase historyUseCase,
        IMLModelService mlService,
        ILogger<PredictionController> logger)
    {
        _predictUseCase = predictUseCase;
        _historyUseCase = historyUseCase;
        _mlService      = mlService;
        _logger         = logger;
    }

    /// <summary>
    /// POST /api/v1/predictions — Dự đoán đột quỵ
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(PredictResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ErrorResponseDto), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Predict(
        [FromBody] PredictRequestDto dto,
        CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ErrorResponseDto
            {
                Error  = "Validation failed",
                Detail = string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage))
            });

        try
        {
            var input = MapToEntity(dto);
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            var result = await _predictUseCase.ExecuteAsync(input, dto.ModelName, ipAddress, null, ct);

            return Ok(MapToDto(result.Result));
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new ErrorResponseDto { Error = ex.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Prediction failed");
            return StatusCode(500, new ErrorResponseDto
            {
                Error  = "Internal server error",
                Detail = ex.Message
            });
        }
    }

    /// <summary>
    /// GET /api/v1/predictions — Lịch sử dự đoán
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(HistoryResponseDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHistory(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken ct = default)
    {
        var (records, total) = await _historyUseCase.ExecuteAsync(page, pageSize, ct);

        var response = new HistoryResponseDto
        {
            Page     = page,
            PageSize = pageSize,
            Total    = total,
            Records  = records.Select(r => new PredictionSummaryDto
            {
                Id          = r.Id,   // string (SERIAL from Supabase)
                ModelName   = r.ModelName,
                Prediction  = r.Result.Prediction,
                Probability = r.Result.Probability,
                RiskLevel   = r.Result.RiskLevel,
                Age         = r.Input.Age,
                PatientCode = r.PatientCode ?? "",
                FullName    = r.Input.FullName ?? "",
                CreatedAt   = r.CreatedAt
            })
        };

        return Ok(response);
    }

    /// <summary>
    /// GET /api/v1/predictions/models — Danh sách model có sẵn
    /// </summary>
    [HttpGet("models")]
    [ProducesResponseType(typeof(ApiInfoDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetModels(CancellationToken ct)
    {
        var models = await _mlService.GetAvailableModelsAsync(ct);
        return Ok(new ApiInfoDto { AvailableModels = models });
    }

    // ── Mapping helpers ─────────────────────────────────────────────
    private static PatientInput MapToEntity(PredictRequestDto dto) => new()
    {
        FullName          = dto.FullName,
        Gender            = dto.Gender,
        Age               = dto.Age,
        Hypertension      = dto.Hypertension,
        HeartDisease      = dto.HeartDisease,
        EverMarried       = dto.EverMarried,
        WorkType          = dto.WorkType,
        ResidenceType     = dto.ResidenceType,
        AvgGlucoseLevel   = dto.AvgGlucoseLevel,
        Bmi               = dto.Bmi,
        SmokingStatus     = dto.SmokingStatus
    };

    private static PredictResponseDto MapToDto(PredictionResult r) => new()
    {
        Prediction  = r.Prediction,
        Probability = r.Probability,
        RiskLevel   = r.RiskLevel,
        Message     = r.Message,
        ModelUsed   = r.ModelUsed,
        PredictedAt = r.PredictedAt
    };
}
