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
        new Link { Label = "New Journal", Url = "/journal", Icon = "fa-solid fa-book" }
    };
}

public class Link
{
    public string Label { get; set; } = null!;
    public string Url { get; set; } = null!;
    public string Icon { get; set; } = null!;
}