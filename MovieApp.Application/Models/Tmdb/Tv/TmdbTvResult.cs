using System.Text.Json.Serialization;

namespace MovieApp.Application.Models.Tmdb.Tv;

public class TmdbTvResult
{
    public bool Adult { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }

    [JsonPropertyName("genre_ids")]
    public List<int> GenreIds { get; set; } = new();

    public int Id { get; set; }

    [JsonPropertyName("origin_country")]
    public List<string> OriginCountry { get; set; } = new();

    [JsonPropertyName("original_language")]
    public string? OriginalLanguage { get; set; }

    [JsonPropertyName("original_name")]
    public string? OriginalName { get; set; }

    public string? Overview { get; set; }

    public double Popularity { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("first_air_date")]
    public DateTime? FirstAirDate { get; set; }

    public string? Name { get; set; }

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
}