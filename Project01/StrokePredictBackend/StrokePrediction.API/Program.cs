using Microsoft.EntityFrameworkCore;
using Serilog;
using StrokePrediction.API.middlewares;
using StrokePrediction.Infrastructure.config;
using StrokePrediction.Infrastructure.database;

// ── Serilog: cấu hình logging ─────────────────────────────────────────────
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {SourceContext}: {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("logs/stroke-api-.log",
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 14)
    .Enrich.FromLogContext()
    .CreateLogger();

try
{
    Log.Information("=== Stroke Prediction API starting ===");

    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog();

    // ── Services ─────────────────────────────────────────────────────────────
    builder.Services.AddControllers(options => 
        {
            options.Filters.Add<StrokePrediction.API.filters.GlobalAuditFilter>();
        })
        .AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
        });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new()
        {
            Title       = "Stroke Prediction API",
            Version     = "v1",
            Description = "API dự đoán đột quỵ sử dụng ML models thuần NumPy"
        });
        var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);
    });

    // CORS — cho phép frontend gọi API
    builder.Services.AddCors(opt =>
    {
        opt.AddPolicy("AllowFrontend", policy =>
        {
            policy.WithOrigins(
                    builder.Configuration.GetSection("AllowedOrigins").Get<string[]>()
                    ?? ["http://localhost:3000", "http://localhost:5173"])
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });

    // Infrastructure + Use Cases (DI)
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddUseCases();

    builder.Services.AddHealthChecks();

    // ── Build App ─────────────────────────────────────────────────────────────
    var app = builder.Build();

    // Schema đã tồn tại trên Supabase — không cần MigrateAsync()
    // Chỉ kiểm tra kết nối khi khởi động
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        try
        {
            await db.Database.CanConnectAsync();
            Log.Information("Supabase connection OK");
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Cannot connect to Supabase. Check connection string in appsettings.json");
            throw;
        }
    }

    // ── Middleware Pipeline ───────────────────────────────────────────────────
    app.UseGlobalExceptionHandler();
    app.UseRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stroke Prediction API v1");
            c.RoutePrefix = string.Empty;   // Swagger tại root "/"
        });
    }

    app.UseCors("AllowFrontend");
    app.UseAuthorization();
    app.MapControllers();
    app.MapHealthChecks("/health");

    Log.Information("Stroke Prediction API is running on {Url}", 
        string.Join(", ", builder.Configuration["urls"] ?? "http://localhost:5000"));

    await app.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "API startup failed");
}
finally
{
    Log.CloseAndFlush();
}
