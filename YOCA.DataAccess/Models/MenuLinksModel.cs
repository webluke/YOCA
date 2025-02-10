namespace YOCA.DataAccess.Models;

public class MenuLinksModel
{
    public string Id { get; set; }
    public int Order { get; set; }
    public int Type { get; set; }
    [Required(ErrorMessage = "Please enter a title"), MaxLength(150)]
    public string Title { get; set; }
    public string URL { get; set; }
    public string MenuName { get; set; }
    public string Icon { get; set; }
}
