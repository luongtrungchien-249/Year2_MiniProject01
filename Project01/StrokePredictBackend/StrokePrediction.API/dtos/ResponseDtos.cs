namespace StrokePrediction.API.dtos;

/// <summary>
/// DTO đầu ra trả về Frontend
/// </summary>
public class PredictResponseDto
{
    public int Prediction { get; set; }
    public double Probability { get; set; }
    public string RiskLevel { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string ModelUsed { get; set; } = string.Empty;
    public DateTime PredictedAt { get; set; }
}

public class HistoryResponseDto
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)Total / PageSize);
    public IEnumerable<PredictionSummaryDto> Records { get; set; } = [];
}

public class PredictionSummaryDto
{
    public string Id { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public int Prediction { get; set; }
    public double Probability { get; set; }
    public string RiskLevel { get; set; } = string.Empty;
    public double Age { get; set; }
    public string PatientCode { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class ErrorResponseDto
{
    public string Error { get; set; } = string.Empty;
    public string? Detail { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}

public class ApiInfoDto
{
    public string Name { get; set; } = "Stroke Prediction API";
    public string Version { get; set; } = "1.0.0";
    public IEnumerable<string> AvailableModels { get; set; } = [];
    public DateTime ServerTime { get; set; } = DateTime.UtcNow;
}
