namespace YOCA.DataAccess.Models;

public class LinkModel
{
    public string Id { get; set; }
    public int Order { get; set; }
    public int Type { get; set; }
    public string Title { get; set; }
    public string URL { get; set; }
    public string MenuName { get; set; }
    public string Icon { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
    public bool IsPublished { get; set; }
}
