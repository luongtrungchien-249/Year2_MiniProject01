using StrokePrediction.Core.entities;

namespace StrokePrediction.Core.interfaces;

public interface IDashboardRepository
{
    Task<DashboardStats> GetSummaryStatsAsync(CancellationToken ct = default);
    Task<IEnumerable<ChartDataPoint>> GetStrokeByAgeGroupAsync(CancellationToken ct = default);
    Task<IEnumerable<ChartDataPoint>> GetGenderDistributionAsync(CancellationToken ct = default);
}

public class DashboardStats
{
    public int TotalPatients { get; set; }
    public int TotalPredictions { get; set; }
    public int StrokeCases { get; set; }
    public double StrokeRatio => TotalPredictions > 0 ? (double)StrokeCases / TotalPredictions : 0;
    public string ActiveModelName { get; set; } = string.Empty;
    public double ActiveModelAccuracy { get; set; }
}

public class ChartDataPoint
{
    public string Label { get; set; } = string.Empty;
    public double Value { get; set; }
}
