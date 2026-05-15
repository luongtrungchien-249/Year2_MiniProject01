namespace StrokePrediction.Core.entities;

/// <summary>
/// Entity: Bệnh nhân gửi request dự đoán đột quỵ
/// </summary>
public class PatientInput
{
    public string? FullName { get; set; }
    public string Gender { get; set; } = string.Empty;
    public double Age { get; set; }
    public int Hypertension { get; set; }       // 0 or 1
    public int HeartDisease { get; set; }        // 0 or 1
    public string EverMarried { get; set; } = string.Empty;
    public string WorkType { get; set; } = string.Empty;
    public string ResidenceType { get; set; } = string.Empty;
    public double AvgGlucoseLevel { get; set; }
    public double? Bmi { get; set; }             // nullable — có thể missing
    public string SmokingStatus { get; set; } = string.Empty;
}
