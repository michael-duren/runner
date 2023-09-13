using Microsoft.JSInterop;

namespace Runner.Application.Services.Theme;

public class AppTheme
{
    private readonly IJSRuntime _js;

    public AppTheme(IJSRuntime js)
    {
        _js = js;
    }

    private bool _isDarkMode = false;

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            _isDarkMode = value;
            _js.InvokeVoidAsync("setDarkMode", value);
        }
    }
}