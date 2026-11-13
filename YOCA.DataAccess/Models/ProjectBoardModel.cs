namespace YOCA.DataAccess.Models;

public class ProjectBoardModel
{
    public string Id { get; set; } = string.Empty;
    public string ProjectId { get; set; } = string.Empty;
    public int Order { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public string? Color { get; set; }
    public string? BackgroundColor { get; set; }
    public List<ProjectTaskModel> Tasks { get; set; } = [];
}
