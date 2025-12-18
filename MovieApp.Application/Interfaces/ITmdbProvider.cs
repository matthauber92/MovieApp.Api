using MovieApp.Application.Models.Tmdb;
using MovieApp.Application.Models.Tmdb.Movie;
using MovieApp.Application.Models.Tmdb.Tv;

namespace MovieApp.Application.Interfaces;

public interface ITmdbProvider
{
    Task<TmdbDiscoverResponse> DiscoverMoviesAsync(
        int page,
        string? genreIds,
        string language = "en-US");

    Task<TmdbSearchResponse> SearchMultiAsync(
        string query,
        int page,
        bool includeAdult = false,
        string language = "en-US");
    
    Task<TmdbMovie> GetMovieAsync(
        int movieId,
        string language = "en-US");
    
    Task<TmdbTvSearchResponse> DiscoverTvAsync(
        int page,
        string? genreIds = null,
        string language = "en-US");

    Task<TmdbTvSearchResponse> SearchTvAsync(
        string query,
        int page = 1,
        string language = "en-US");
}

