﻿namespace YOCA.Fluent.Models;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string BackgroundColor { get; set; }
    public string Icon { get; set; }
    public string UnicodeIcon { get; set; }
}

public class Statuses
{
    public Dictionary<int, Status> DefaultStatuses = new();

    public Statuses()
    {
        // Progress State Statuses (0 - 99)
        DefaultStatuses.Add(0, new Status { Id = 0, Name = "New", Description = "New", Color = "White", BackgroundColor = "LightSlateGray", Icon = "fas fa-lightbulb", UnicodeIcon = "&#xf0eb;" });
        DefaultStatuses.Add(10, new Status { Id = 10, Name = "Under Review", Description = "Under Review", Color = "White", BackgroundColor = "SlateBlue", Icon = "fas fa-magnifying-glass", UnicodeIcon = "&#xf002;" });
        DefaultStatuses.Add(30, new Status { Id = 20, Name = "In Progress", Description = "In Progress", Color = "White", BackgroundColor = "DodgerBlue", Icon = "fas fa-hammer", UnicodeIcon = "&#xf6e3;" });
        DefaultStatuses.Add(50, new Status { Id = 50, Name = "On Hold", Description = "On Hold", Color = "Black", BackgroundColor = "Khaki", Icon = "fas fa-pause", UnicodeIcon = "&#xf04c;" });
        DefaultStatuses.Add(51, new Status { Id = 51, Name = "Blocking", Description = "Blocking", Color = "White", BackgroundColor = "SandyBrown", Icon = "fas fa-hand", UnicodeIcon = "&#xf256;" });
        DefaultStatuses.Add(100, new Status { Id = 100, Name = "Completed", Description = "Completed", Color = "White", BackgroundColor = "SeaGreen", Icon = "fas fa-flag-checkered", UnicodeIcon = "&#xf11e;" });
        // Bad State Statuses (200-299
        DefaultStatuses.Add(200, new Status { Id = 200, Name = "Cancelled", Description = "Cancelled", Color = "White", BackgroundColor = "Maroon", Icon = "fas fa-ban", UnicodeIcon = "&#xf05e;" });
        DefaultStatuses.Add(300, new Status { Id = 300, Name = "Hidden", Description = "Hidden", Color = "Black", BackgroundColor = "GhostWhite", Icon = "fas fa-ghost", UnicodeIcon = "&#xf6e2;" });

    }
}
