using StrokePrediction.Core.entities;

namespace StrokePrediction.Core.interfaces;

/// <summary>
/// Interface: ML Model Service (Python bridge)
/// Cho phép thay thế Python subprocess bằng bất kỳ implementation nào
/// </summary>
public interface IMLModelService
{
    Task<PredictionResult> PredictAsync(PatientInput input, string modelName = "stacking", double? threshold = null, CancellationToken ct = default);
    Task<IEnumerable<string>> GetAvailableModelsAsync(CancellationToken ct = default);
    bool IsModelLoaded(string modelName);
}
