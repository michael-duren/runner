using Microsoft.AspNetCore.Components;
using Runner.Application.Models;
using Runner.Pages.Shared;

namespace Runner.Pages;

public partial class Dashboard
{
    [CascadingParameter]
    public MainLayout? Layout { get; set; }
    private User? user => Layout.User;
}
