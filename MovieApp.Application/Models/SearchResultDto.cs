namespace MovieApp.Application.Models.Tmdb;

public class SearchResultDto
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty; // movie | tv

    public string Title { get; set; } = string.Empty;
    public string? Subtitle { get; set; }

    public string? ImagePath { get; set; }
    public double Popularity { get; set; }
}
