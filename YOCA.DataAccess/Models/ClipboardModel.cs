namespace YOCA.DataAccess.Models;

public class ClipboardModel
{
    public string Id { get; set; }
    public int Order { get; set; }
    public int Status { get; set; }
    public string Title { get; set; }
    public string Note { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
}
