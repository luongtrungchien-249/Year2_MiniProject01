using StrokePrediction.Core.entities;
using StrokePrediction.Core.interfaces;
using Microsoft.Extensions.Logging;

namespace StrokePrediction.Core.usecases;

public class PredictStrokeUseCase
{
    private readonly IMLModelService _mlService;
    private readonly IPredictionRepository _repository;
    private readonly ILogger<PredictStrokeUseCase> _logger;

    public PredictStrokeUseCase(
        IMLModelService mlService,
        IPredictionRepository repository,
        ILogger<PredictStrokeUseCase> logger)
    {
        _mlService  = mlService;
        _repository = repository;
        _logger     = logger;
    }

    public async Task<PredictionRecord> ExecuteAsync(
        PatientInput input,
        string modelName = "stacking",
        string? ipAddress = null,
        int? userId = null,
        CancellationToken ct = default)
    {
        _logger.LogInformation(
            "Predicting stroke | Age={Age}, Model={Model}, UserId={UserId}",
            input.Age, modelName, userId);

        // 0. Lấy threshold từ active model trong CSDL
        var activeModel = await _repository.GetActiveModelAsync(ct);
        double threshold = 0.5; // Mặc định an toàn
        if (activeModel != null)
        {
            threshold = (double)activeModel.Threshold;
        }

        // 1. Predict
        var result = await _mlService.PredictAsync(input, modelName, threshold, ct);

        var record = new PredictionRecord
        {
            Input     = input,
            Result    = result,
            ModelName = modelName,
            UserId    = userId,
            IpAddress = ipAddress
        };

        var saved = await _repository.SaveAsync(record, ct);

        _logger.LogInformation(
            "Saved prediction #{Id} | PatientCode={Code} | Risk={Risk}",
            saved.Id, saved.PatientCode, saved.Result.RiskLevel);

        return saved;
    }
}
