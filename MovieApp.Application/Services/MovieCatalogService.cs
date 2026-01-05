using MovieApp.Application.Interfaces;
using MovieApp.Application.Models.Tmdb;
using MovieApp.Application.Models.Tmdb.Movie;

namespace MovieApp.Application.Services;

public class MovieCatalogService : IMovieCatalogService
{
    private readonly ITmdbProvider _tmdb;

    public MovieCatalogService(ITmdbProvider tmdb)
    {
        _tmdb = tmdb;
    }

    public Task<TmdbDiscoverResponse> DiscoverMoviesAsync(int page, string? genreIds = null)
    {
        return _tmdb.DiscoverMoviesAsync(page, genreIds);
    }
    
    public async Task<List<SearchResultDto>> SearchAsync(string query, int page)
    {
        var tmdbResponse = await _tmdb.SearchMultiAsync(query, page);

        return tmdbResponse.Results
            .Where(i => i.MediaType is "movie" or "tv")
            .Select(item => new SearchResultDto
            {
                Id = item.Id,
                Type = item.MediaType,
                Title = item.MediaType == "movie"
                    ? item.Title ?? "Unknown"
                    : item.Name ?? "Unknown",
                ImagePath = item.PosterPath,
                BackdropPath = item.BackdropPath,
                Popularity = item.Popularity,
                ReleaseDate = item.MediaType == "movie"
                    ? item.ReleaseDate
                    : item.FirstAirDate
            })
            .ToList();
    }
    
    public async Task<TmdbMovie> GetMovieAsync(int movieId)
    {
        return await _tmdb.GetMovieAsync(movieId);
    }
}
