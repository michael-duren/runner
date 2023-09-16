using Microsoft.AspNetCore.Components;
using Runner.Application.Models;
using Runner.Pages.Shared;

namespace Runner.Pages;

public partial class Dashboard
{
    [CascadingParameter] public MainLayout? Layout { get; set; }
    private User? user => Layout.User;

    private List<Link> Links { get; set; } = new List<Link>
    {
        new Link { Label = "Journal", Url = "/journal", Icon = "fa-solid fa-book" },
        new Link { Label = "Schedule", Url = "/schedule", Icon = "fa-solid fa-calendar" },
        new Link { Label = "Goals", Url = "/goals", Icon = "fa-solid fa-bullseye" },
        new Link { Label = "Stats", Url = "/stats", Icon = "fa-solid fa-chart-bar" },
        new Link { Label = "Settings", Url = "/settings", Icon = "fa-solid fa-cog" }
    };
}

public class Link
{
    public string Label { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Icon { get; set; } = null!;
}