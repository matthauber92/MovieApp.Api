using MovieApp.Application.Models;

namespace MovieApp.Application.Interfaces;

public interface IMovieCatalogService
{
    Task<TmdbDiscoverResponse> DiscoverActionMoviesAsync(int page);
    Task<List<SearchResultDto>> SearchAsync(string query, int page);
}
