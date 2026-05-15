using StrokePrediction.Core.entities;
using StrokePrediction.Core.interfaces;
using Microsoft.Extensions.Logging;

namespace StrokePrediction.Core.usecases;

/// <summary>
/// Use Case: Lấy lịch sử dự đoán (phân trang)
/// </summary>
public class GetPredictionHistoryUseCase
{
    private readonly IPredictionRepository _repository;
    private readonly ILogger<GetPredictionHistoryUseCase> _logger;

    public GetPredictionHistoryUseCase(
        IPredictionRepository repository,
        ILogger<GetPredictionHistoryUseCase> logger)
    {
        _repository = repository;
        _logger     = logger;
    }

    public async Task<(IEnumerable<PredictionRecord> Records, int Total)> ExecuteAsync(
        int page = 1, int pageSize = 20, CancellationToken ct = default)
    {
        page     = Math.Max(1, page);
        pageSize = Math.Clamp(pageSize, 1, 100);

        var records = await _repository.GetAllAsync(page, pageSize, ct);
        var total   = await _repository.CountAsync(ct);

        _logger.LogInformation("History fetched: Page={Page}, Total={Total}", page, total);
        return (records, total);
    }
}
