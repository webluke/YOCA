namespace YOCA.DataAccess.Models;

public class ClipboardModel
{
    public string Id { get; set; } = string.Empty;
    public int Order { get; set; }
    public int Status { get; set; }
    public DateOnly DateCompleted { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    public string? Note { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
}
