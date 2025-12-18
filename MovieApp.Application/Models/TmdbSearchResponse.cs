namespace MovieApp.Application.Models;

public class TmdbSearchResponse
{
    public int Page { get; set; }
    public List<TmdbSearchResult> Results { get; set; } = new();
}
