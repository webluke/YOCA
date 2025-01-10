namespace YOCA.DataAccess.Models;

public class DayOfCodeModel
{
    public string Id { get; set; }
    public int Day { get; set; }
    public DateOnly Date { get; set; }
    public string? Goal { get; set; }
    public string? Result { get; set; }
    public string? Tomorrow { get; set; }
    public string? Summary { get; set; }
    public DateTime TimeCreated { get; set; }
    public DateTime TimeUpdated { get; set; }
    public int ViewCount { get; set; }
}
