using MudBlazor;

namespace YOCA.Web.Models;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public MudBlazor.Color Color { get; set; }
    public string Icon { get; set; }
}

public class Statuses
{
    public Dictionary<int, Status> DefaultStatuses = new();

    public Statuses()
    {
        // Progress State Statuses (0 - 99)
        DefaultStatuses.Add(0, new Status { Id = 0, Name = "New", Description = "New", Color = MudBlazor.Color.Default, Icon = MudBlazor.Icons.Material.Rounded.FiberNew });
        DefaultStatuses.Add(1, new Status { Id = 1, Name = "Under Review", Description = "Under Review", Color = MudBlazor.Color.Warning, Icon = MudBlazor.Icons.Material.Rounded.Preview });
        DefaultStatuses.Add(2, new Status { Id = 2, Name = "In Progress", Description = "In Progress", Color = MudBlazor.Color.Info, Icon = MudBlazor.Icons.Material.Rounded.Build });
        DefaultStatuses.Add(3, new Status { Id = 3, Name = "On Hold", Description = "On Hold", Color = MudBlazor.Color.Primary, Icon = MudBlazor.Icons.Material.Rounded.Pause });
        DefaultStatuses.Add(4, new Status { Id = 4, Name = "Completed", Description = "Completed", Color = MudBlazor.Color.Success, Icon = MudBlazor.Icons.Material.Rounded.CheckBox });
        // Bad State Statuses (200-299
        DefaultStatuses.Add(200, new Status { Id = 200, Name = "Cancelled", Description = "Cancelled", Color = MudBlazor.Color.Error, Icon = MudBlazor.Icons.Material.Rounded.CancelPresentation });
        DefaultStatuses.Add(300, new Status { Id = 300, Name = "Hidden", Description = "Hidden", Color = MudBlazor.Color.Dark, Icon = MudBlazor.Icons.Material.Filled.NotificationsPaused });

    }
}
