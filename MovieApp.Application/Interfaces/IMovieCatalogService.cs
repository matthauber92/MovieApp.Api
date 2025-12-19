using MovieApp.Application.Models.Tmdb;
using MovieApp.Application.Models.Tmdb.Movie;

namespace MovieApp.Application.Interfaces;

public interface IMovieCatalogService
{
    Task<TmdbDiscoverResponse> DiscoverMoviesAsync(int page, string? genreIds = null);
    Task<List<SearchResultDto>> SearchAsync(string query, int page);
    Task<TmdbMovie> GetMovieAsync(int movieId);
}
