namespace StrokePrediction.Infrastructure.config;

/// <summary>
/// Cấu hình ứng dụng — load từ appsettings.json
/// </summary>
public class AppSettings
{
    public DatabaseSettings Database { get; set; } = new();
    public JwtSettings Jwt { get; set; } = new();
    public PythonSettings Python { get; set; } = new();
    public ModelSettings Models { get; set; } = new();
}

public class DatabaseSettings
{
    public string ConnectionString { get; set; } = string.Empty;
}

public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = "StrokePredictionAPI";
    public string Audience { get; set; } = "StrokePredictionClients";
    public int ExpiresInMinutes { get; set; } = 60;
}

public class PythonSettings
{
    public string PythonExePath { get; set; } = "python";
    public string ScriptPath { get; set; } = "scripts/predict.py";
    public string ExportedModelsDir { get; set; } = "exported_models";
    public string NgrokUrl { get; set; } = string.Empty;
    public int TimeoutMs { get; set; } = 10000;
}

public class ModelSettings
{
    public string DefaultModel { get; set; } = "stacking";
    public List<string> AvailableModels { get; set; } =
        ["decision_tree", "random_forest", "knn", "adaboost", "stacking"];
}
