using MovieApp.Application.Models.Tmdb;
using MovieApp.Application.Models.Tmdb.Movie;

namespace MovieApp.Application.Interfaces;

public interface IMovieCatalogService
{
    Task<TmdbDiscoverResponse> DiscoverActionMoviesAsync(int page);
    Task<List<SearchResultDto>> SearchAsync(string query, int page);
    Task<TmdbMovie> GetMovieAsync(int movieId);
}
