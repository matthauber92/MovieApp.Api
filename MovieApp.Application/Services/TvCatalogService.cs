using MovieApp.Application.Interfaces;
using MovieApp.Application.Models.Tmdb;
using MovieApp.Application.Models.Tmdb.Tv;

namespace MovieApp.Application.Services;

public class TvCatalogService : ITvCatalogService
{
    private readonly ITmdbProvider _tmdb;

    public TvCatalogService(ITmdbProvider tmdb)
    {
        _tmdb = tmdb;
    }

    public async Task<TmdbTvSearchResponse> DiscoverTvAsync(
        int page,
        string? genreIds = null)
    {
        return await _tmdb.DiscoverTvAsync(page, genreIds);
    }
    
    public async Task<List<SearchResultDto>> SearchTvAsync(
        string query,
        int page)
    {
        var tmdbResponse = await _tmdb.SearchTvAsync(query, page);

        var results = new List<SearchResultDto>();

        foreach (var item in tmdbResponse.Results)
        {
            results.Add(new SearchResultDto
            {
                Id = item.Id,
                Type = "tv",
                Title = item.Name
                        ?? item.OriginalName
                        ?? "Unknown",
                ImagePath = item.PosterPath,
                Popularity = item.Popularity,
                Subtitle = item.FirstAirDate.HasValue
                    ? $"First aired {item.FirstAirDate:yyyy}"
                    : null
            });
        }

        return results
            .OrderByDescending(r => r.Popularity)
            .ToList();
    }
}