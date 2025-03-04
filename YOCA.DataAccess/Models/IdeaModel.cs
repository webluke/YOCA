namespace YOCA.DataAccess.Models;

public class IdeaModel
{
    public string Id { get; set; }
    public int Order { get; set; }
    public int Status { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(50)]
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
}
