using System.Text.Json.Serialization;
using MovieApp.Application.Models.Tmdb.Movie;

public class TmdbDiscoverResponse
{
    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("results")]
    public List<TmdbMovieDto> Results { get; set; } = new();
}