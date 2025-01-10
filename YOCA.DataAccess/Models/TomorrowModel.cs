namespace YOCA.DataAccess.Models;

public class TomorrowModel
{
    private DateOnly date;
    private int day;

    public string Id { get; set; }
    public int Day
    {
        get { return day + 1; }
        set { day = value; }
    }
    public DateOnly Date
    {
        get { return date.AddDays(1); }
        set { date = value; }
    }
    public string? Tomorrow { get; set; }
}
