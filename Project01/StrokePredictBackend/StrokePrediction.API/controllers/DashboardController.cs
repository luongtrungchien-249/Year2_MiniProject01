using Microsoft.AspNetCore.Mvc;
using StrokePrediction.Core.interfaces;

namespace StrokePrediction.API.controllers;

[ApiController]
[Route("api/v1/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardRepository _repo;

    public DashboardController(IDashboardRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats(CancellationToken ct)
    {
        var stats = await _repo.GetSummaryStatsAsync(ct);
        return Ok(stats);
    }

    [HttpGet("chart/age")]
    public async Task<IActionResult> GetAgeChart(CancellationToken ct)
    {
        var data = await _repo.GetStrokeByAgeGroupAsync(ct);
        return Ok(data);
    }

    [HttpGet("chart/gender")]
    public async Task<IActionResult> GetGenderChart(CancellationToken ct)
    {
        var data = await _repo.GetGenderDistributionAsync(ct);
        return Ok(data);
    }
}
