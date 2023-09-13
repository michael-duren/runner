using Microsoft.AspNetCore.Components;
using Runner.Application.Models;

namespace Runner.Pages.Shared;

public partial class NavMenu
{
    [CascadingParameter]
    public MainLayout? Layout { get; set; }
    private User? user => Layout?.User;
}
