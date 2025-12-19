using MovieApp.Application.Models.Tmdb;
using MovieApp.Application.Models.Tmdb.Tv;

namespace MovieApp.Application.Interfaces;

public interface ITvCatalogService
{
    Task<TmdbTvSearchResponse> DiscoverTvAsync(
        int page,
        string? genreIds = null);

    Task<List<SearchResultDto>> SearchTvAsync(
        string query,
        int page);

}