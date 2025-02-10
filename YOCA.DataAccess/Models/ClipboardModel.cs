namespace YOCA.DataAccess.Models;

public class ClipboardModel
{
    public string Id { get; set; }
    public int Order { get; set; }
    public int Status { get; set; }
    public DateOnly DateCompleted { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(150)]
    public string Title { get; set; }
    public string Note { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
}
