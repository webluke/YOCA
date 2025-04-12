namespace YOCA.DataAccess.Models;

public class ProjectBoardModel
{
    public string Id { get; set; }
    public string ProjectId { get; set; }
    public int Order { get; set; }
    public string Title { get; set; }
    public List<ProjectTaskModel> Tasks { get; set; }
}
