namespace YOCA.DataAccess.Models;

public class ProjectBoardModel
{
    public string Id { get; set; }
    public string ProjectId { get; set; }
    public int Order { get; set; }
    public string Title { get; set; }
    public string Icon { get; set; } /*= "fas fa-clipboard-list";*/
    public string Color { get; set; } /*= "White";*/
    public string BackgroundColor { get; set; } /*= "DodgerBlue";*/
    public List<ProjectTaskModel> Tasks { get; set; }
}
