using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;
namespace MovieApp.Api;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private readonly IMovieCatalogService _movies;

    public MoviesController(IMovieCatalogService movies)
    {
        _movies = movies;
    }

    [HttpGet]
    public async Task<IActionResult> GetActionMovies(
        [FromQuery] int page = 1)
    {
        var result = await _movies.DiscoverActionMoviesAsync(page);
        return Ok(result);
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> Search(
        [FromQuery] string query,
        [FromQuery] int page = 1)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("Query is required.");

        var results = await _movies.SearchAsync(query, page);

        return Ok(results);
    }
}