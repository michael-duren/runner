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
            _js.InvokeVoidAsync("setDarkMode", value); // set the theme and update the css
            OnChange?.Invoke();
        }
    }

    public void SaveThemePreference()
    {
        _js.InvokeVoidAsync("saveThemePreference", _isDarkMode); // save to local storage
    }

    public async Task<bool> IsBrowserDarkMode() => await _js.InvokeAsync<bool>("isBrowserDarkMode");

    public event Action OnChange;

    public async Task ListenForThemeChanges()
    {
        var dotnetHelper = DotNetObjectReference.Create(this); // create a reference to this class
        await _js.InvokeVoidAsync("addThemeEventListener", dotnetHelper);
    }

    [JSInvokable]
    public async Task SetDarkMode(bool isDarkMode) => IsDarkMode = isDarkMode;
}