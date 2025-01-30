namespace YOCA.DataAccess.Models;

public class RewindModel
{
    public string Id { get; set; }
    public DateOnly Date {get; set;}
    public int Year {get; set;}
    public int Month {get; set;}
    public string Title {get; set;}
    public string Slug {get; set;}
    public string Content {get; set;}
    public DateTime TimeCreated {get; set;}
    public DateTime TimeUpdated {get; set;}
    public int ViewCount {get; set;}
    public bool IsPublished {get; set;}
}
