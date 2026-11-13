global using System.ComponentModel.DataAnnotations;

namespace YOCA.DataAccess.Models;

public class PageModel
{
    public string Id { get; set; } = string.Empty;
    public int Order { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(150)]
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string? MenuName { get; set; }
    public string? Icon { get; set; }
    public string? Content { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
    public int ViewCount { get; set; }
    public bool IsPublished { get; set; }
}
