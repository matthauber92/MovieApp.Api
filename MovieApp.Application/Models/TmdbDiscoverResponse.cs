namespace MovieApp.Application.Models;

public class TmdbDiscoverResponse
{
    public int Page { get; set; }
    public List<TmdbMovieDto> Results { get; set; } = new();
}
