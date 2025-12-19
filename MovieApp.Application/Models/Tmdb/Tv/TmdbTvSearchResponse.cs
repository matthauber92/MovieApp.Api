namespace MovieApp.Application.Models.Tmdb.Tv;

public class TmdbTvSearchResponse
{
    public int Page { get; set; }

    public List<TmdbTvResult> Results { get; set; } = new();

    public int TotalPages { get; set; }

    public int TotalResults { get; set; }
}