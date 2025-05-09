﻿namespace YOCA.Web.Models;

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
        DefaultStatuses.Add(0, new Status { Id = 0, Name = "New", Description = "New", Color = MudBlazor.Color.Default, Icon = "fas fa-lightbulb" });
        DefaultStatuses.Add(10, new Status { Id = 10, Name = "Under Review", Description = "Under Review", Color = MudBlazor.Color.Warning, Icon = "fas fa-magnifying-glass" });
        DefaultStatuses.Add(30, new Status { Id = 20, Name = "In Progress", Description = "In Progress", Color = MudBlazor.Color.Info, Icon = "fas fa-hammer" });
        DefaultStatuses.Add(50, new Status { Id = 50, Name = "On Hold", Description = "On Hold", Color = MudBlazor.Color.Primary, Icon = "fas fa-pause" });
        DefaultStatuses.Add(51, new Status { Id = 51, Name = "Blocking", Description = "Blocking", Color = MudBlazor.Color.Warning, Icon = "fas fa-hand" });
        DefaultStatuses.Add(100, new Status { Id = 100, Name = "Completed", Description = "Completed", Color = MudBlazor.Color.Success, Icon = "fas fa-flag-checkered" });
        // Bad State Statuses (200-299
        DefaultStatuses.Add(200, new Status { Id = 200, Name = "Cancelled", Description = "Cancelled", Color = MudBlazor.Color.Error, Icon = "fas fa-ban" });
        DefaultStatuses.Add(300, new Status { Id = 300, Name = "Hidden", Description = "Hidden", Color = MudBlazor.Color.Dark, Icon = "fas fa-ghost" });

    }
}
