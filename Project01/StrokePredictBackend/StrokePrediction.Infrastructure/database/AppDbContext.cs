using Microsoft.EntityFrameworkCore;
using StrokePrediction.Core.entities;

namespace StrokePrediction.Infrastructure.database;

/// <summary>
/// EF Core DbContext — ánh xạ đúng schema Supabase hiện có.
/// Các bảng: users, ml_models, patients, predictions, audit_logs.
/// Không tạo migration — schema đã tồn tại trên Supabase.
/// </summary>
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<UserEntity>        Users        => Set<UserEntity>();
    public DbSet<MlModelEntity>     MlModels     => Set<MlModelEntity>();
    public DbSet<PatientEntity>     Patients     => Set<PatientEntity>();
    public DbSet<PredictionEntity>  Predictions  => Set<PredictionEntity>();
    public DbSet<AuditLogEntity>    AuditLogs    => Set<AuditLogEntity>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // ── Đăng ký PostgreSQL enums cho EF Core ─────────────────────
        mb.HasPostgresEnum<UserRole>("user_role_enum");
        mb.HasPostgresEnum<ModelName>("model_name_enum");
        mb.HasPostgresEnum<Strategy>("strategy_enum");
        mb.HasPostgresEnum<Gender>("gender_enum");
        mb.HasPostgresEnum<Married>("married_enum");
        mb.HasPostgresEnum<WorkType>("work_type_enum");
        mb.HasPostgresEnum<Residence>("residence_enum");
        mb.HasPostgresEnum<Smoking>("smoking_enum");
        mb.HasPostgresEnum<RiskLevel>("risk_level_enum");
        mb.HasPostgresEnum<AuditAction>("audit_action_enum");
        // ──────────────────────────────────────────────────────────────
        // 1. USERS
        // ──────────────────────────────────────────────────────────────
        mb.Entity<UserEntity>(e =>
        {
            e.ToTable("users");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            e.Property(x => x.Username).HasColumnName("username").HasMaxLength(50).IsRequired();
            e.Property(x => x.Email).HasColumnName("email").HasMaxLength(100).IsRequired();
            e.Property(x => x.PasswordHash).HasColumnName("password_hash").HasMaxLength(255).IsRequired();
            e.Property(x => x.FullName).HasColumnName("full_name").HasMaxLength(100);
            e.Property(x => x.Role).HasColumnName("role")
             .HasColumnType("user_role_enum");
            e.Property(x => x.IsActive).HasColumnName("is_active").HasDefaultValue(true);
            e.Property(x => x.LastLoginAt).HasColumnName("last_login_at");
            e.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
            e.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
            e.HasIndex(x => x.Email).HasDatabaseName("idx_users_email");
            e.HasIndex(x => x.Username).HasDatabaseName("idx_users_username");
        });

        // ──────────────────────────────────────────────────────────────
        // 2. ML_MODELS
        // ──────────────────────────────────────────────────────────────
        mb.Entity<MlModelEntity>(e =>
        {
            e.ToTable("ml_models");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            e.Property(x => x.Name).HasColumnName("name")
             .HasColumnType("model_name_enum").IsRequired();
            e.Property(x => x.Version).HasColumnName("version").HasMaxLength(20).HasDefaultValue("1.0");
            e.Property(x => x.ImbalanceStrategy).HasColumnName("imbalance_strategy")
             .HasColumnType("strategy_enum").IsRequired();
            e.Property(x => x.BestParams).HasColumnName("best_params").HasColumnType("jsonb");
            e.Property(x => x.Accuracy).HasColumnName("accuracy").HasColumnType("decimal(6,4)");
            e.Property(x => x.AucScore).HasColumnName("auc_score").HasColumnType("decimal(6,4)");
            e.Property(x => x.F1Score).HasColumnName("f1_score").HasColumnType("decimal(6,4)");
            e.Property(x => x.RecallScore).HasColumnName("recall_score").HasColumnType("decimal(6,4)");
            e.Property(x => x.PrecisionScore).HasColumnName("precision_score").HasColumnType("decimal(6,4)");
            e.Property(x => x.Specificity).HasColumnName("specificity").HasColumnType("decimal(6,4)");
            e.Property(x => x.ConfusionMatrix).HasColumnName("confusion_matrix").HasColumnType("jsonb");
            e.Property(x => x.Threshold).HasColumnName("threshold").HasColumnType("decimal(4,2)").HasDefaultValue(0.50m);
            e.Property(x => x.ModelFilePath).HasColumnName("model_file_path").HasMaxLength(500);
            e.Property(x => x.TrainingSamples).HasColumnName("training_samples");
            e.Property(x => x.TrainingDuration).HasColumnName("training_duration").HasColumnType("decimal(10,2)");
            e.Property(x => x.IsActive).HasColumnName("is_active").HasDefaultValue(false);
            e.Property(x => x.TrainedAt).HasColumnName("trained_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
            e.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        // ──────────────────────────────────────────────────────────────
        // 3. PATIENTS
        // ──────────────────────────────────────────────────────────────
        mb.Entity<PatientEntity>(e =>
        {
            e.ToTable("patients");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            e.Property(x => x.PatientCode).HasColumnName("patient_code").HasMaxLength(12);
            e.Property(x => x.UserId).HasColumnName("user_id");
            e.Property(x => x.FullName).HasColumnName("full_name").HasMaxLength(100);
            e.Property(x => x.Phone).HasColumnName("phone").HasMaxLength(20);
            e.Property(x => x.Gender).HasColumnName("gender").HasColumnType("gender_enum").IsRequired();
            e.Property(x => x.Age).HasColumnName("age").HasColumnType("decimal(5,2)").IsRequired();
            e.Property(x => x.Hypertension).HasColumnName("hypertension").HasDefaultValue((short)0);
            e.Property(x => x.HeartDisease).HasColumnName("heart_disease").HasDefaultValue((short)0);
            e.Property(x => x.EverMarried).HasColumnName("ever_married").HasColumnType("married_enum").IsRequired();
            e.Property(x => x.WorkType).HasColumnName("work_type").HasColumnType("work_type_enum").IsRequired();
            e.Property(x => x.ResidenceType).HasColumnName("Residence_type").HasColumnType("residence_enum").IsRequired();
            e.Property(x => x.AvgGlucoseLevel).HasColumnName("avg_glucose_level").HasColumnType("decimal(8,2)").IsRequired();
            e.Property(x => x.Bmi).HasColumnName("bmi").HasColumnType("decimal(5,2)");
            e.Property(x => x.SmokingStatus).HasColumnName("smoking_status").HasColumnType("smoking_enum").IsRequired();
            e.Property(x => x.Stroke).HasColumnName("stroke");
            e.Property(x => x.Notes).HasColumnName("notes");
            e.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
            e.Property(x => x.UpdatedAt).HasColumnName("updated_at").HasDefaultValueSql("CURRENT_TIMESTAMP");

            e.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);
            e.HasIndex(x => x.PatientCode).HasDatabaseName("idx_patients_code");
        });

        // ──────────────────────────────────────────────────────────────
        // 4. PREDICTIONS
        // ──────────────────────────────────────────────────────────────
        mb.Entity<PredictionEntity>(e =>
        {
            e.ToTable("predictions");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            e.Property(x => x.PatientId).HasColumnName("patient_id").IsRequired();
            e.Property(x => x.ModelId).HasColumnName("model_id").IsRequired();
            e.Property(x => x.UserId).HasColumnName("user_id");
            e.Property(x => x.Prediction).HasColumnName("prediction").IsRequired();
            e.Property(x => x.Probability).HasColumnName("probability").HasColumnType("decimal(6,4)").IsRequired();
            e.Property(x => x.ThresholdUsed).HasColumnName("threshold_used").HasColumnType("decimal(4,2)").HasDefaultValue(0.50m);
            e.Property(x => x.RiskLevel).HasColumnName("risk_level").HasColumnType("risk_level_enum").IsRequired();
            e.Property(x => x.InputSnapshot).HasColumnName("input_snapshot").HasColumnType("jsonb").IsRequired();
            e.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");

            e.HasOne(x => x.Patient).WithMany(x => x.Predictions).HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.MlModel).WithMany().HasForeignKey(x => x.ModelId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);
            e.HasIndex(x => x.CreatedAt).HasDatabaseName("idx_pred_created");
        });

        // ──────────────────────────────────────────────────────────────
        // 5. AUDIT_LOGS
        // ──────────────────────────────────────────────────────────────
        mb.Entity<AuditLogEntity>(e =>
        {
            e.ToTable("audit_logs");
            e.HasKey(x => x.Id);
            e.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            e.Property(x => x.UserId).HasColumnName("user_id");
            e.Property(x => x.Action).HasColumnName("action")
             .HasColumnType("audit_action_enum").IsRequired();
            e.Property(x => x.EntityType).HasColumnName("entity_type").HasMaxLength(50);
            e.Property(x => x.EntityId).HasColumnName("entity_id");
            e.Property(x => x.Detail).HasColumnName("detail").HasColumnType("jsonb");
            e.Property(x => x.IpAddress).HasColumnName("ip_address").HasMaxLength(45);
            e.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("CURRENT_TIMESTAMP");
            e.HasIndex(x => x.CreatedAt).HasDatabaseName("idx_audit_created");
        });
    }
}

// ══════════════════════════════════════════════════════════════
// ENTITY CLASSES — ánh xạ từng bảng Supabase
// ══════════════════════════════════════════════════════════════
public class UserEntity
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? FullName { get; set; }
    public UserRole Role { get; set; } = UserRole.patient;
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class MlModelEntity
{
    public int Id { get; set; }
    public ModelName Name { get; set; }
    public string Version { get; set; } = "1.0";
    public Strategy ImbalanceStrategy { get; set; }
    public string? BestParams { get; set; }          // JSONB
    public decimal? Accuracy { get; set; }
    public decimal? AucScore { get; set; }
    public decimal? F1Score { get; set; }
    public decimal? RecallScore { get; set; }
    public decimal? PrecisionScore { get; set; }
    public decimal? Specificity { get; set; }
    public string? ConfusionMatrix { get; set; }     // JSONB
    public decimal Threshold { get; set; } = 0.50m;
    public string? ModelFilePath { get; set; }
    public int? TrainingSamples { get; set; }
    public decimal? TrainingDuration { get; set; }
    public bool IsActive { get; set; } = false;
    public DateTime TrainedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class PatientEntity
{
    public int Id { get; set; }
    public string? PatientCode { get; set; }         // Tự sinh bởi trigger Supabase
    public int? UserId { get; set; }
    public string? FullName { get; set; }
    public string? Phone { get; set; }
    public Gender Gender { get; set; } = Gender.Male;
    public decimal Age { get; set; }
    public short Hypertension { get; set; } = 0;
    public short HeartDisease { get; set; } = 0;
    public Married EverMarried { get; set; } = Married.No;
    public WorkType WorkType { get; set; } = WorkType.Private;
    public Residence ResidenceType { get; set; } = Residence.Urban;
    public decimal AvgGlucoseLevel { get; set; }
    public decimal? Bmi { get; set; }
    public Smoking SmokingStatus { get; set; } = Smoking.Unknown;
    public short? Stroke { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation
    public UserEntity? User { get; set; }
    public ICollection<PredictionEntity> Predictions { get; set; } = [];
}

public class PredictionEntity
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int ModelId { get; set; }
    public int? UserId { get; set; }
    public short Prediction { get; set; }
    public decimal Probability { get; set; }
    public decimal ThresholdUsed { get; set; } = 0.50m;
    public RiskLevel RiskLevel { get; set; } = RiskLevel.Low;   // Tự tính bởi trigger Supabase
    public string InputSnapshot { get; set; } = "{}"; // JSONB
    public DateTime CreatedAt { get; set; }

    // Navigation
    public PatientEntity Patient { get; set; } = null!;
    public MlModelEntity MlModel { get; set; } = null!;
    public UserEntity? User { get; set; }
}

public class AuditLogEntity
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public AuditAction Action { get; set; }
    public string? EntityType { get; set; }
    public int? EntityId { get; set; }
    public string? Detail { get; set; }    // JSONB
    public string? IpAddress { get; set; }
    public DateTime CreatedAt { get; set; }
}
