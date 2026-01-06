using System.Text.Json.Serialization;

namespace MovieApp.Application.Models.Tmdb.Tv;

public class TmdbTvResult
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; } = string.Empty;

    public string Overview { get; set; } = string.Empty;

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath { get; set; }

    [JsonPropertyName("first_air_date")]
    public DateTime? FirstAirDate { get; set; }

    [JsonPropertyName("last_air_date")]
    public DateTime? LastAirDate { get; set; }

    [JsonPropertyName("number_of_seasons")]
    public int NumberOfSeasons { get; set; }
    
    public List<TmdbSeason> Seasons { get; set; } = new();

    [JsonPropertyName("number_of_episodes")]
    public int NumberOfEpisodes { get; set; }

    [JsonPropertyName("episode_run_time")]
    public List<int> EpisodeRunTime { get; set; } = new();

    public bool Adult { get; set; }

    [JsonPropertyName("in_production")]
    public bool InProduction { get; set; }

    public double Popularity { get; set; }

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }

    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }

    public List<TmdbGenre> Genres { get; set; } = new();

    [JsonPropertyName("created_by")]
    public List<TmdbCreatedBy> CreatedBy { get; set; } = new();

    public List<TmdbNetwork> Networks { get; set; } = new();

    [JsonPropertyName("origin_country")]
    public List<string> OriginCountry { get; set; } = new();

    public string? Homepage { get; set; }

    [JsonPropertyName("last_episode_to_air")]
    public TmdbEpisode? LastEpisodeToAir { get; set; }

    [JsonPropertyName("next_episode_to_air")]
    public TmdbEpisode? NextEpisodeToAir { get; set; }
    [JsonPropertyName("credits")]
    public TmdbTvCredits? Credits { get; set; }
}

public class TmdbTvCredits
{
    public List<TmdbTvCastMember> Cast { get; set; } = new();
}

public class TmdbTvCastMember
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


public class TmdbGenre
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}


public class TmdbCreatedBy
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; } = string.Empty;

    public int Gender { get; set; }

    [JsonPropertyName("profile_path")]
    public string? ProfilePath { get; set; }
}

public class TmdbNetwork
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("logo_path")]
    public string? LogoPath { get; set; }

    [JsonPropertyName("origin_country")]
    public string OriginCountry { get; set; } = string.Empty;
}

public class TmdbEpisode
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Overview { get; set; } = string.Empty;

    [JsonPropertyName("air_date")]
    public DateTime? AirDate { get; set; }

    [JsonPropertyName("season_number")]
    public int SeasonNumber { get; set; }

    [JsonPropertyName("episode_number")]
    public int EpisodeNumber { get; set; }

    public int? Runtime { get; set; }

    [JsonPropertyName("still_path")]
    public string? StillPath { get; set; }
}

public class TmdbSeason
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Overview { get; set; }

    [JsonPropertyName("season_number")]
    public int SeasonNumber { get; set; }

    [JsonPropertyName("episode_count")]
    public int EpisodeCount { get; set; }

    [JsonPropertyName("air_date")]
    public DateTime? AirDate { get; set; }

    [JsonPropertyName("poster_path")]
    public string? PosterPath { get; set; }

    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
}
