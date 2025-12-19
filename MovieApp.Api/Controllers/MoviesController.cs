using Microsoft.AspNetCore.Mvc;
using MovieApp.Application.Interfaces;

namespace MovieApp.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private readonly IMovieCatalogService _movies;

    public MoviesController(IMovieCatalogService movies)
    {
        _movies = movies;
    }

    // GET api/movies?page=1
    [HttpGet]
    public async Task<IActionResult> GetMovies(
        [FromQuery] int page = 1,
        [FromQuery] string? genreIds = null
        )
    {
        var result = await _movies.DiscoverMoviesAsync(page, genreIds);
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
    
    [HttpGet("{movieId:int}")]
    public async Task<IActionResult> GetMovie(
        [FromRoute] int movieId)
    {
        if (movieId <= 0)
            return BadRequest("Invalid movie id.");

        var movie = await _movies.GetMovieAsync(movieId);
        
        return Ok(movie);
    }
}