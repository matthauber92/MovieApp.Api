using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;

namespace MovieApp.Api.Controllers;

[ApiController]
[Route("api/tv")]
public class TvController : ControllerBase
{
    private readonly ITvCatalogService _tv;

    public TvController(ITvCatalogService tv)
    {
        _tv = tv;
    }

    [HttpGet]
    public async Task<IActionResult> DiscoverTv(
        [FromQuery] int page = 1,
        [FromQuery] string? genreIds = null)
    {
        var result = await _tv.DiscoverTvAsync(page, genreIds);
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string query,
        [FromQuery] int page = 1)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("Query is required.");

        var results = await _tv.SearchTvAsync(query, page);
        return Ok(results);
    }
    
    [HttpGet("{seriesId:int}")]
    public async Task<IActionResult> GetSeries(
        [FromRoute] int seriesId)
    {
        if (seriesId <= 0)
            return BadRequest("Invalid series id.");

        var series = await _tv.GetSeriesByIdAsync(seriesId);
        
        return Ok(series);
    }
}