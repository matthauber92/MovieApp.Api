using System.Text.Json.Serialization;

namespace MovieApp.Application.Models.Tmdb.Movie;

public class TmdbMovie
{
    public int Id { get; set; }
    public bool Adult { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }

    [JsonPropertyName("belongs_to_collection")]
    public TmdbCollection? BelongsToCollection { get; set; }

    public int Budget { get; set; }

    public List<TmdbGenre> Genres { get; set; } = new();

    public string? Homepage { get; set; }

    [JsonPropertyName("imdb_id")]
    public string? ImdbId { get; set; }

    [JsonPropertyName("origin_country")]
    public List<string> OriginCountry { get; set; } = new();

    [JsonPropertyName("original_language")]
    public string? OriginalLanguage { get; set; }

    [JsonPropertyName("original_title")]
    public string? OriginalTitle { get; set; }

    public string? Overview { get; set; }

    public double Popularity { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("production_companies")]
    public List<TmdbProductionCompany> ProductionCompanies { get; set; } = new();

    [JsonPropertyName("production_countries")]
    public List<TmdbProductionCountry> ProductionCountries { get; set; } = new();

    [JsonPropertyName("release_date")]
    public DateTime? ReleaseDate { get; set; }

    public long Revenue { get; set; }

    public int Runtime { get; set; }

    [JsonPropertyName("spoken_languages")]
    public List<TmdbSpokenLanguage> SpokenLanguages { get; set; } = new();

    public string? Status { get; set; }

    public string? Tagline { get; set; }

    public string? Title { get; set; }

    public bool Video { get; set; }

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    
    [JsonPropertyName("credits")]
    public TmdbCredits? Credits { get; set; }
}

public class TmdbCollection
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }
}

public class TmdbGenre
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class TmdbProductionCompany
{
    public int Id { get; set; }

    [JsonPropertyName("logo_path")]
    public string? LogoPath { get; set; }

    public string? Name { get; set; }

    [JsonPropertyName("origin_country")]
    public string? OriginCountry { get; set; }
}

public class TmdbProductionCountry
{
    [JsonPropertyName("iso_3166_1")]
    public string? Iso31661 { get; set; }

    public string? Name { get; set; }
}

public class TmdbSpokenLanguage
{
    [JsonPropertyName("english_name")]
    public string? EnglishName { get; set; }

    [JsonPropertyName("iso_639_1")]
    public string? Iso6391 { get; set; }

    public string? Name { get; set; }
}

public class TmdbCredits
{
    public List<TmdbCastMember> Cast { get; set; } = new();
}

public class TmdbCastMember
{
    public int Id { get; set; }
    public string? Name { get; set; }

    [JsonPropertyName("character")]
    public string? Character { get; set; }

    [JsonPropertyName("profile_path")]
    public string? ProfilePath { get; set; }

    [JsonPropertyName("profileImageUrl")]
    public string? ProfileImageUrl =>
        ProfilePath == null
            ? null
            : $"https://image.tmdb.org/t/p/w185{ProfilePath}";

    [JsonPropertyName("order")]
    public int Order { get; set; }
}


