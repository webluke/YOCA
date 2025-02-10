namespace YOCA.DataAccess.Models;

public class ProjectTaskModel
{
    public string Id { get; set; }
    public string ProjectId { get; set; }
    public int Order { get; set; }
    public int Status { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(150)]
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
}
