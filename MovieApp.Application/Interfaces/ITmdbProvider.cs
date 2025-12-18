using MovieApp.Application.Models;

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
}

