namespace StrokePrediction.Core.entities;

/// <summary>
/// Entity: Kết quả dự đoán đột quỵ
/// </summary>
public class PredictionResult
{
    public int Prediction { get; set; }            // 0 = không, 1 = đột quỵ
    public double Probability { get; set; }        // Xác suất [0, 1]
    public string RiskLevel { get; set; } = string.Empty;  // Thấp / Trung bình / Cao / Rất cao
    public string Message { get; set; } = string.Empty;
    public string ModelUsed { get; set; } = string.Empty;
    public DateTime PredictedAt { get; set; } = DateTime.UtcNow;
}
