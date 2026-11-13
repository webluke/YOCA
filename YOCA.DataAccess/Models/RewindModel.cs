namespace YOCA.DataAccess.Models;

public class RewindModel
{
    public string Id { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    [Required]
    [MinLength(2020)]
    [MaxLength(2100)]
    public int Year { get; set; }
    [Required]
    [MinLength(1)]
    [MaxLength(12)]
    public int Month { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(150)]
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? Content { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
    public int ViewCount { get; set; }
    public bool IsPublished { get; set; }
}
