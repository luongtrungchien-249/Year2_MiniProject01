using Microsoft.EntityFrameworkCore;
using StrokePrediction.Core.interfaces;
using StrokePrediction.Infrastructure.database;

namespace StrokePrediction.Infrastructure.repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly AppDbContext _db;

    public DashboardRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<DashboardStats> GetSummaryStatsAsync(CancellationToken ct = default)
    {
        var totalPatients = await _db.Patients.CountAsync(ct);
        var totalPreds = await _db.Predictions.CountAsync(ct);
        var strokeCases = await _db.Predictions.CountAsync(p => p.Prediction == 1, ct);
        
        var activeModel = await _db.MlModels.FirstOrDefaultAsync(m => m.IsActive, ct);

        return new DashboardStats
        {
            TotalPatients = totalPatients,
            TotalPredictions = totalPreds,
            StrokeCases = strokeCases,
            ActiveModelName = activeModel?.Name.ToString() ?? "N/A",
            ActiveModelAccuracy = (double)(activeModel?.Accuracy ?? 0)
        };
    }

    public async Task<IEnumerable<ChartDataPoint>> GetStrokeByAgeGroupAsync(CancellationToken ct = default)
    {
        // Nhóm theo tuổi: <30, 30-45, 45-60, >60
        var strokePatients = await _db.Predictions
            .Where(p => p.Prediction == 1)
            .Include(p => p.Patient)
            .Select(p => p.Patient.Age)
            .ToListAsync(ct);

        return new List<ChartDataPoint>
        {
            new() { Label = "<30", Value = strokePatients.Count(a => a < 30) },
            new() { Label = "30-45", Value = strokePatients.Count(a => a >= 30 && a < 45) },
            new() { Label = "45-60", Value = strokePatients.Count(a => a >= 45 && a < 60) },
            new() { Label = ">60", Value = strokePatients.Count(a => a >= 60) }
        };
    }

    public async Task<IEnumerable<ChartDataPoint>> GetGenderDistributionAsync(CancellationToken ct = default)
    {
        var data = await _db.Patients
            .GroupBy(p => p.Gender)
            .Select(g => new ChartDataPoint
            {
                Label = g.Key.ToString(),
                Value = g.Count()
            })
            .ToListAsync(ct);
            
        return data;
    }
}
