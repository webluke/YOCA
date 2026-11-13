namespace YOCA.DataAccess.Models;

public class ProjectTaskModel
{
    public string Id { get; set; } = string.Empty;
    public string ProjectId { get; set; } = string.Empty;
    public string BoardId { get; set; } = string.Empty;
    public int Order { get; set; }
    public int Status { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(150)]
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
    public bool Hidden { get; set; }
}
