using System.Text.Json.Serialization;

namespace MovieApp.Application.Models.Tmdb;

public class SearchResultDto
{
    public int Id { get; set; }
    public string Type { get; set; } = ""; // movie | tv

    public string Title { get; set; } = "";
    public string? Subtitle { get; set; }

    public string? ImagePath { get; set; }
    public string? BackdropPath { get; set; }

    public double Popularity { get; set; }
    public double VoteAverage { get; set; }
}


public class TmdbSearchItem
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("media_type")]
    public string MediaType { get; set; } = "";

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }

    [JsonPropertyName("overview")]
    public string? Overview { get; set; }

    [JsonPropertyName("popularity")]
    public double Popularity { get; set; }

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }

    [JsonPropertyName("first_air_date")]
    public DateTime? FirstAirDate { get; set; }

    [JsonPropertyName("release_date")]
    public DateTime? ReleaseDate { get; set; }
}

