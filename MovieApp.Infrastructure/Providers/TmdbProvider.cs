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
        _apiKey = "507916d1889dbe2a0bc48e45a6b7e79d";
    }

    public async Task<TmdbDiscoverResponse> DiscoverMoviesAsync(
        int page,
        string? genreIds,
        string language = "en-US")
    {
        var today = DateTime.UtcNow.ToString("yyyy-MM-dd");

        var url =
            $"discover/movie" +
            $"?api_key={_apiKey}" +
            $"&page={page}" +
            $"&language={language}" +
            $"&primary_release_date.lte={today}" +
            $"&include_adult=false" +
            $"&sort_by=popularity.desc";

        if (genreIds == "-1" || genreIds == null)
        {
            url += "&vote_count.gte=300";
            url += "&vote_average.gte=6.5";
        }
        else
        {
            url += $"&with_genres={genreIds}";
        }

        var data = await _http.GetFromJsonAsync<TmdbDiscoverResponse>(url)
                   ?? new TmdbDiscoverResponse();

        return data;
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

        var response = await _http.GetFromJsonAsync<TmdbSearchResponse>(url)
                       ?? new TmdbSearchResponse();

        // Filter out people only
        response.Results = response.Results
            .Where(r => r.MediaType == "movie" || r.MediaType == "tv")
            .ToList();

        return response;
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
            $"&language={language}" +
            $"&include_adult=false" +
            $"&sort_by=popularity.desc";

        if (genreIds == "-1" || genreIds == null)
        {
            url += "&vote_count.gte=200";
            url += "&vote_average.gte=6.8";
        }
        else
        {
            url += $"&with_genres={genreIds}";
        }

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
    
    public async Task<TmdbTvResult> GetSeriesByIdAsync(
        int seriesId,
        string language = "en-US")
    {
        var url =
            $"tv/{seriesId}" +
            $"?api_key={_apiKey}" +
            $"&language={language}";

        return await _http.GetFromJsonAsync<TmdbTvResult>(url)
               ?? throw new InvalidOperationException(
                   $"TMDB returned null for TV series {seriesId}");
    }
}
