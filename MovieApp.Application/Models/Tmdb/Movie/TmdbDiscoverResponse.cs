using MovieApp.Application.Models.Tmdb.Movie;

namespace MovieApp.Application.Models.Tmdb;

public class TmdbDiscoverResponse
{
    public int Page { get; set; }
    public List<TmdbMovieDto> Results { get; set; } = new();
}
