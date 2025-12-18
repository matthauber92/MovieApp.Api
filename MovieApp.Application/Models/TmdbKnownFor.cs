namespace MovieApp.Application.Models;

using System.Text.Json.Serialization;

public class TmdbKnownFor
{
    public int Id { get; set; }

    [JsonPropertyName("media_type")]
    public string MediaType { get; set; } = string.Empty;

    public string? Title { get; set; }
    
    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }

    public double Popularity { get; set; }
}

