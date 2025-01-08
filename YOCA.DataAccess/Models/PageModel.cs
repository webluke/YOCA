namespace YOCA.DataAccess.Models;

public class PageModel
{
    public string Id { get; set; }
    public int Order { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string MenuName { get; set; }
    public string Icon { get; set; }
    public string Content { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
    public int ViewCount { get; set; }
    public bool IsPublished { get; set; }
}
