using MovieApp.Application.Interfaces;
using MovieApp.Application.Models;
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
        var url =
            $"discover/movie" +
            $"?api_key={_apiKey}" +
            $"&page={page}" +
            $"&language={language}";

        if (!string.IsNullOrWhiteSpace(genreIds))
            url += $"&with_genres={genreIds}";
        Console.WriteLine(_http.GetStringAsync(url));
        var response = await _http.GetFromJsonAsync<TmdbDiscoverResponse>(url);

        return response ?? new TmdbDiscoverResponse();
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

}