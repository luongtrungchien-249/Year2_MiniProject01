using Microsoft.EntityFrameworkCore;
using StrokePrediction.Core.entities;
using StrokePrediction.Core.interfaces;
using StrokePrediction.Infrastructure.database;
using System.Text.Json;

namespace StrokePrediction.Infrastructure.repositories;

/// <summary>
/// Triển khai IPredictionRepository với schema Supabase thực tế.
/// Flow: PatientInput → INSERT patients → INSERT predictions → trả PredictionRecord.
/// risk_level tự tính bởi trigger Supabase, không cần set trong code.
/// patient_code tự sinh bởi trigger PAT-XXXXX.
/// </summary>
public class PredictionRepository : IPredictionRepository
{
    private readonly AppDbContext _db;
    private static readonly JsonSerializerOptions _jsonOpts = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public PredictionRepository(AppDbContext db) => _db = db;

    // ── Lưu prediction mới vào Supabase ─────────────────────────────────────
    public async Task<PredictionRecord> SaveAsync(
        PredictionRecord record, CancellationToken ct = default)
    {
        // 1. Tìm hoặc tạo Patient
        var patient = await GetOrCreatePatientAsync(record.Input, record.UserId, ct);

        // 2. Lấy active model
        var activeModel = await _db.MlModels
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.IsActive, ct)
            ?? throw new InvalidOperationException("Không có ML model nào đang active trong DB.");

        // 3. Serialize input snapshot (sau khi xử lý — giá trị raw để audit)
        var inputSnapshot = JsonSerializer.Serialize(record.Input, _jsonOpts);

        // 4. INSERT prediction (risk_level do trigger Supabase tự tính)
        var predEntity = new PredictionEntity
        {
            PatientId     = patient.Id,
            ModelId       = activeModel.Id,
            UserId        = record.UserId,
            Prediction    = (short)record.Result.Prediction,
            Probability   = (decimal)record.Result.Probability,
            ThresholdUsed = (decimal)activeModel.Threshold,
            RiskLevel     = RiskLevel.Low,   // Placeholder — trigger Supabase ghi đè ngay
            InputSnapshot = inputSnapshot,
            CreatedAt     = record.CreatedAt
        };

        _db.Predictions.Add(predEntity);
        await _db.SaveChangesAsync(ct);

        // 5. Reload để lấy risk_level thực tế từ trigger
        await _db.Entry(predEntity).ReloadAsync(ct);

        // 6. Ghi Audit Log
        await WriteAuditAsync(record.UserId, AuditAction.PREDICT,
            "prediction", predEntity.Id, record.IpAddress, ct);

        record.Id         = predEntity.Id.ToString();
        record.PatientCode = patient.PatientCode;
        record.Result.RiskLevel = predEntity.RiskLevel.ToString().Replace("_", " ");

        return record;
    }

    // ── Lịch sử dự đoán (phân trang) ────────────────────────────────────────
    public async Task<IEnumerable<PredictionRecord>> GetAllAsync(
        int page, int pageSize, CancellationToken ct = default)
    {
        var entities = await _db.Predictions
            .Include(p => p.Patient)
            .Include(p => p.MlModel)
            .Include(p => p.User)
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(ct);

        return entities.Select(MapToDomain);
    }

    public async Task<PredictionRecord?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        if (!int.TryParse(id, out var intId)) return null;
        var entity = await _db.Predictions
            .Include(p => p.Patient)
            .Include(p => p.MlModel)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == intId, ct);
        return entity is null ? null : MapToDomain(entity);
    }

    public Task<int> CountAsync(CancellationToken ct = default)
        => _db.Predictions.CountAsync(ct);

    // ── Lấy Active Model Info ─────────────────────────────────────────────────
    public async Task<MlModelInfo?> GetActiveModelAsync(CancellationToken ct = default)
    {
        var m = await _db.MlModels.AsNoTracking().FirstOrDefaultAsync(m => m.IsActive, ct);
        return m == null ? null : new MlModelInfo 
        { 
            Id = m.Id, 
            Name = m.Name.ToString(), 
            Threshold = m.Threshold, 
            IsActive = m.IsActive 
        };
    }

    // ── Private helpers ───────────────────────────────────────────────────────
    private async Task<PatientEntity> GetOrCreatePatientAsync(
        PatientInput input, int? userId, CancellationToken ct)
    {
        // Map input sang entity — trigger Supabase tự sinh patient_code
        var patient = new PatientEntity
        {
            UserId            = userId,
            FullName          = string.IsNullOrWhiteSpace(input.FullName) ? "Bệnh nhân mới" : input.FullName,
            Gender            = Enum.Parse<Gender>(input.Gender, true),
            Age               = (decimal)input.Age,
            Hypertension      = (short)input.Hypertension,
            HeartDisease      = (short)input.HeartDisease,
            EverMarried       = Enum.Parse<Married>(input.EverMarried, true),
            WorkType          = Enum.Parse<WorkType>(input.WorkType, true),
            ResidenceType     = Enum.Parse<Residence>(input.ResidenceType, true),
            AvgGlucoseLevel   = (decimal)input.AvgGlucoseLevel,
            Bmi               = input.Bmi.HasValue ? (decimal?)input.Bmi.Value : null,
            SmokingStatus     = Enum.Parse<Smoking>(input.SmokingStatus, true),
            CreatedAt         = DateTime.UtcNow,
            UpdatedAt         = DateTime.UtcNow
        };

        _db.Patients.Add(patient);
        await _db.SaveChangesAsync(ct);
        
        // Reload để lấy patient_code do trigger Supabase sinh
        await _db.Entry(patient).ReloadAsync(ct);
        return patient;
    }

    private async Task WriteAuditAsync(
        int? userId, AuditAction action, string entityType,
        int entityId, string? ipAddress, CancellationToken ct)
    {
        _db.AuditLogs.Add(new AuditLogEntity
        {
            UserId     = userId,
            Action     = action,
            EntityType = entityType,
            EntityId   = entityId,
            IpAddress  = ipAddress,
            CreatedAt  = DateTime.UtcNow
        });
        await _db.SaveChangesAsync(ct);
    }

    private static PredictionRecord MapToDomain(PredictionEntity e) => new()
    {
        Id            = e.Id.ToString(),
        PatientCode   = e.Patient?.PatientCode,
        ModelName     = e.MlModel?.Name.ToString() ?? string.Empty,
        DoctorName    = e.User?.FullName,
        Input = new PatientInput
        {
            Gender          = e.Patient?.Gender.ToString() ?? string.Empty,
            Age             = (double)(e.Patient?.Age ?? 0),
            Hypertension    = e.Patient?.Hypertension ?? 0,
            HeartDisease    = e.Patient?.HeartDisease ?? 0,
            EverMarried     = e.Patient?.EverMarried.ToString() ?? string.Empty,
            WorkType        = e.Patient?.WorkType.ToString() ?? string.Empty,
            ResidenceType   = e.Patient?.ResidenceType.ToString() ?? string.Empty,
            AvgGlucoseLevel = (double)(e.Patient?.AvgGlucoseLevel ?? 0),
            Bmi             = e.Patient?.Bmi.HasValue == true ? (double?)e.Patient.Bmi : null,
            SmokingStatus   = e.Patient?.SmokingStatus.ToString() ?? string.Empty
        },
        Result = new PredictionResult
        {
            Prediction  = e.Prediction,
            Probability = (double)e.Probability,
            RiskLevel   = e.RiskLevel.ToString().Replace("_", " "),
            Message     = e.Prediction == 1 ? "Có nguy cơ đột quỵ!" : "Không có nguy cơ đột quỵ.",
            ModelUsed   = e.MlModel?.Name.ToString() ?? string.Empty,
            PredictedAt = e.CreatedAt
        },
        UserId     = e.UserId,
        CreatedAt  = e.CreatedAt
    };
}
