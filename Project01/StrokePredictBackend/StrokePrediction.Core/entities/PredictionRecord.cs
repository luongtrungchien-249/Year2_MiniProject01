namespace StrokePrediction.Core.entities;

/// <summary>
/// Domain entity: Lịch sử một lần dự đoán — ánh xạ từ Supabase predictions table.
/// patient_code và risk_level được tự sinh bởi trigger PostgreSQL.
/// </summary>
public class PredictionRecord
{
    public string Id { get; set; } = string.Empty;      // predictions.id (SERIAL)
    public string? PatientCode { get; set; }            // patients.patient_code (PAT-XXXXX)
    public string? DoctorName { get; set; }             // users.full_name
    public PatientInput Input { get; set; } = null!;
    public PredictionResult Result { get; set; } = null!;
    public string ModelName { get; set; } = string.Empty;
    public int? UserId { get; set; }
    public string? IpAddress { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
