namespace YOCA.DataAccess.Models;

public class LinkModel
{
    public string Id { get; set; } = string.Empty;
    public int Order { get; set; }
    public int Type { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(150)]
    public string Title { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please enter a URL"), MaxLength(2000)]
    public string URL { get; set; } = string.Empty;
    public string? MenuName { get; set; }
    public string? Icon { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
    public bool IsPublished { get; set; }
}
