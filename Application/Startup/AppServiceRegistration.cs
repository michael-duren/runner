using Runner.Application.Database;
using Runner.Application.Events.Listeners;
using Runner.Application.Models;
using Runner.Application.Services.Auth;
using Runner.Application.Services;
using Spark.Library.Database;
using Spark.Library.Logging;
using Coravel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Spark.Library.Auth;
using Runner.Application.Jobs;
using Runner.Application.Services.Theme;
using Runner.Pages;
using Spark.Library.Mail;
using Vite.AspNetCore.Extensions;

namespace Runner.Application.Startup;

public static class AppServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddCustomServices();
        services.AddViteServices();
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddDatabase<DatabaseContext>(config);
        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddLogger(config);
        services.AddAuthorization(config, new string[] { CustomRoles.Admin, CustomRoles.User });
        services.AddAuthentication<IAuthValidator>(config);
        services.AddScoped<AuthenticationStateProvider, SparkAuthenticationStateProvider>();
        services.AddJobServices();
        services.AddScheduler();
        services.AddQueue();
        services.AddEventServices();
        services.AddEvents();
        services.AddMailer(config);
        return services;
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        // add custom services
        services.AddScoped<UsersService>();
        services.AddScoped<RolesService>();
        services.AddScoped<IAuthValidator, AuthValidator>();
        services.AddScoped<AuthService>();
        services.AddScoped<AppTheme>();
        return services;
    }

    private static IServiceCollection AddEventServices(this IServiceCollection services)
    {
        // add custom events here
        services.AddTransient<EmailNewUser>();
        return services;
    }

    private static IServiceCollection AddJobServices(this IServiceCollection services)
    {
        // add custom background tasks here
        services.AddTransient<ExampleJob>();
        return services;
    }
}