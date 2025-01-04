namespace YOCA.DataAccess.Models;

public class ProjectModel
{
    public string Id { get; set; }
    public int Order { get; set; }
    public int Status { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
    public int ViewCount { get; set; }

    public List<ProjectTaskModel> Tasks { get; set; }
}
