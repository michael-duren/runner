window.setDarkMode = (isDarkMode) => {
  if (isDarkMode) {
    document.body.classList.add("dark");
  } else {
    document.body.classList.remove("dark");
  }
};

const prefersDarkQuery = "(prefers-color-scheme: dark)";

window.isBrowserDarkMode = () => window.matchMedia(prefersDarkQuery).matches;

window.addThemeEventListener = (dotnet) => {
  window.matchMedia(prefersDarkQuery).addEventListener("change", (e) => {
    dotnet.invokeMethodAsync("SetDarkMode", e.matches);
  });
};
window.saveThemePreference = (isDarkMode) => {
  localStorage.setItem("dark-mode", isDarkMode ? "dark" : "light");
};
window.loadThemePreference = () => {
  return localStorage.getItem("dark-mode");
};
