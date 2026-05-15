using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrokePrediction.Infrastructure.database;

namespace StrokePrediction.API.controllers;

[ApiController]
[Route("api/v1/stats")]
public class StatsController : ControllerBase
{
    private readonly AppDbContext _db;

    public StatsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboardStats()
    {
        var totalScans = await _db.Predictions.CountAsync();
        var strokeDetected = await _db.Predictions.CountAsync(p => p.Prediction == 1);
        var normal = totalScans - strokeDetected;
        var spamRate = totalScans == 0 ? 0 : (double)strokeDetected / totalScans;

        // Lấy 50 lịch sử gần nhất
        var recentHistory = await _db.Predictions
            .Include(p => p.Patient)
            .OrderByDescending(p => p.CreatedAt)
            .Take(50)
            .Select(p => new {
                p.Id,
                PatientCode = p.Patient.PatientCode,
                Result = p.Prediction == 1 ? "Nguy cơ Đột quỵ" : "Bình thường",
                p.Probability,
                p.CreatedAt
            })
            .ToListAsync();

        return Ok(new
        {
            TotalScans = totalScans,
            StrokeDetected = strokeDetected,
            Normal = normal,
            SpamRate = spamRate,
            RecentHistory = recentHistory
        });
    }
}
