using Microsoft.EntityFrameworkCore;
using StrokePrediction.Infrastructure.database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace StrokePrediction.Infrastructure.config;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ── Supabase / PostgreSQL ─────────────────────────────────────────────
        // Npgsql 8+ yêu cầu dùng NpgsqlDataSourceBuilder để map PostgreSQL custom enums.
        // Nếu không, INSERT sẽ lỗi: "column X is of type X_enum but expression is of type text"
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var dataSourceBuilder = new Npgsql.NpgsqlDataSourceBuilder(connectionString);

        // Sử dụng translator giữ nguyên tên enum (không lowercase)
        var nameTranslator = new Npgsql.NameTranslation.NpgsqlNullNameTranslator();

        // Map tất cả PostgreSQL custom enums — giữ nguyên case
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.UserRole>("user_role_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.ModelName>("model_name_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.Strategy>("strategy_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.Gender>("gender_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.Married>("married_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.WorkType>("work_type_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.Residence>("residence_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.Smoking>("smoking_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.RiskLevel>("risk_level_enum", nameTranslator);
        dataSourceBuilder.MapEnum<StrokePrediction.Core.entities.AuditAction>("audit_action_enum", nameTranslator);

        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(dataSource,
                npgsql => npgsql.CommandTimeout(30)
            )
            // Không dùng MigrateAsync() — schema đã tồn tại trên Supabase
        );

        // ── Settings ──────────────────────────────────────────────────────────
        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

        // ── Repositories ──────────────────────────────────────────────────────
        services.AddScoped<StrokePrediction.Core.interfaces.IPredictionRepository,
                           repositories.PredictionRepository>();
        services.AddScoped<StrokePrediction.Core.interfaces.IAuditRepository,
                           repositories.AuditRepository>();
        services.AddScoped<StrokePrediction.Core.interfaces.IDashboardRepository,
                           repositories.DashboardRepository>();

        // ── ML Model Service (Python bridge) ─────────────────────────────────
        services.AddSingleton<StrokePrediction.Core.interfaces.IMLModelService,
                              externalapi.PythonMLBridgeService>();

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<StrokePrediction.Core.usecases.PredictStrokeUseCase>();
        services.AddScoped<StrokePrediction.Core.usecases.GetPredictionHistoryUseCase>();
        return services;
    }
}
