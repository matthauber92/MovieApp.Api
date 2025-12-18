using MovieApp.Application.Interfaces;
using MovieApp.Application.Models;
namespace MovieApp.Application.Services;

public class MovieCatalogService : IMovieCatalogService
{
    private readonly ITmdbProvider _tmdb;

    public MovieCatalogService(ITmdbProvider tmdb)
    {
        _tmdb = tmdb;
    }

    public Task<TmdbDiscoverResponse> DiscoverActionMoviesAsync(int page)
    {
        // Action genre = 28
        return _tmdb.DiscoverMoviesAsync(page, genreIds: "28");
    }
    
    public async Task<List<SearchResultDto>> SearchAsync(string query, int page)
    {
        var tmdbResponse = await _tmdb.SearchMultiAsync(query, page);

        var results = new List<SearchResultDto>();

        foreach (var item in tmdbResponse.Results)
        {
            if (item.MediaType == "movie")
            {
                results.Add(new SearchResultDto
                {
                    Id = item.Id,
                    Type = "movie",
                    Title = item.Title ?? "",
                    ImagePath = item.PosterPath,
                    Popularity = item.Popularity
                });
            }
            else if (item.MediaType == "person" && item.KnownFor?.Any() == true)
            {
                var known = item.KnownFor
                    .OrderByDescending(k => k.Popularity)
                    .First();

                results.Add(new SearchResultDto
                {
                    Id = item.Id,
                    Type = "person",
                    Title = item.Name ?? "",
                    Subtitle = $"Known for {known.Title}",
                    ImagePath = item.ProfilePath,
                    Popularity = item.Popularity
                });
            }
        }

        return results;
    }
}
