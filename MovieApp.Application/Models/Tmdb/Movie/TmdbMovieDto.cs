namespace MovieApp.Application.Models.Tmdb.Movie;

public class TmdbMovieDto
{
    public int Id { get; set; }
    public bool Adult { get; set; }
    public string Title { get; set; } = string.Empty;
    public string OriginalTitle { get; set; } = string.Empty;
    public string OriginalLanguage { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;

    public string? PosterPath { get; set; }
    public string? BackdropPath { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public List<int> GenreIds { get; set; } = new();

    public double Popularity { get; set; }
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
}
