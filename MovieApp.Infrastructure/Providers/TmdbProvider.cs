using MovieApp.Application.Interfaces;
using MovieApp.Application.Models.Tmdb;
using MovieApp.Application.Models.Tmdb.Movie;
using MovieApp.Application.Models.Tmdb.Tv;
using System.Net.Http.Json;

namespace MovieApp.Infrastructure.Providers;

public class TmdbProvider : ITmdbProvider
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public TmdbProvider(HttpClient http)
    {
        _http = http;
        _apiKey = "507916d1889dbe2a0bc48e45a6b7e79d"; // move to config later
    }

    public async Task<TmdbDiscoverResponse> DiscoverMoviesAsync(
        int page,
        string? genreIds,
        string language = "en-US")
    {
        var url =
            $"discover/movie" +
            $"?api_key={_apiKey}" +
            $"&page={page}" +
            $"&language={language}";

        if (!string.IsNullOrWhiteSpace(genreIds))
            url += $"&with_genres={genreIds}";

        return await _http.GetFromJsonAsync<TmdbDiscoverResponse>(url)
               ?? new TmdbDiscoverResponse();
    }

    public async Task<TmdbSearchResponse> SearchMultiAsync(
        string query,
        int page = 1,
        bool includeAdult = false,
        string language = "en-US")
    {
        var url =
            $"search/multi" +
            $"?api_key={_apiKey}" +
            $"&query={Uri.EscapeDataString(query)}" +
            $"&page={page}" +
            $"&language={language}" +
            $"&include_adult={includeAdult.ToString().ToLower()}";

        return await _http.GetFromJsonAsync<TmdbSearchResponse>(url)
               ?? new TmdbSearchResponse();
    }

    public async Task<TmdbMovie> GetMovieAsync(
        int movieId,
        string language = "en-US")
    {
        var url =
            $"movie/{movieId}" +
            $"?api_key={_apiKey}" +
            $"&language={language}";

        return await _http.GetFromJsonAsync<TmdbMovie>(url)
               ?? throw new InvalidOperationException(
                   $"TMDB returned null for movie {movieId}");
    }

    public async Task<TmdbTvSearchResponse> DiscoverTvAsync(
        int page,
        string? genreIds = null,
        string language = "en-US")
    {
        var url =
            $"discover/tv" +
            $"?api_key={_apiKey}" +
            $"&page={page}" +
            $"&language={language}";

        if (!string.IsNullOrWhiteSpace(genreIds))
            url += $"&with_genres={genreIds}";

        return await _http.GetFromJsonAsync<TmdbTvSearchResponse>(url)
               ?? new TmdbTvSearchResponse();
    }

    public async Task<TmdbTvSearchResponse> SearchTvAsync(
        string query,
        int page = 1,
        string language = "en-US")
    {
        var url =
            $"search/tv" +
            $"?api_key={_apiKey}" +
            $"&query={Uri.EscapeDataString(query)}" +
            $"&page={page}" +
            $"&language={language}";

        return await _http.GetFromJsonAsync<TmdbTvSearchResponse>(url)
               ?? new TmdbTvSearchResponse();
    }
}
