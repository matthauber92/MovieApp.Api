namespace MovieApp.Application.Models.Tmdb;

public class TmdbSearchResponse
{
    public int Page { get; set; }
    public List<TmdbSearchResult> Results { get; set; } = new();
}
