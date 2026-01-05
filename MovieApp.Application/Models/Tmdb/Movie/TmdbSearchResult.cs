using System.Text.Json.Serialization;
using MovieApp.Application.Models.Tmdb;

namespace MovieApp.Application.Models;

public class TmdbSearchResult
{
    public int Id { get; set; }

    [JsonPropertyName("media_type")]
    public string MediaType { get; set; } = string.Empty;

    public bool Adult { get; set; }

    public string? Title { get; set; }
    public string? Name { get; set; }

    public string? Overview { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }

    [JsonPropertyName("profile_path")]
    public string? ProfilePath { get; set; }
    
    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }
    [JsonPropertyName("first_air_date")]
    public string? FirstAirDate { get; set; }

    public double Popularity { get; set; }

    [JsonPropertyName("known_for")]
    public List<TmdbKnownFor>? KnownFor { get; set; }
}

