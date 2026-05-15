using StrokePrediction.Core.entities;

namespace StrokePrediction.Core.interfaces;

public interface IPredictionRepository
{
    Task<PredictionRecord> SaveAsync(PredictionRecord record, CancellationToken ct = default);
    Task<IEnumerable<PredictionRecord>> GetAllAsync(int page, int pageSize, CancellationToken ct = default);
    Task<PredictionRecord?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<int> CountAsync(CancellationToken ct = default);
    Task<MlModelInfo?> GetActiveModelAsync(CancellationToken ct = default);
}
