using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IncidentApp;

public class App : Application
{
    private static IHost? _host;

    private static IHost Host => _host ??= CreateHostBuilder().Build();

    public static IServiceProvider Services => Host.Services;

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        await Host.StartAsync();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();

            desktop.MainWindow = Services.GetRequiredService<MainWindow>();
            desktop.ShutdownRequested += async (_, _) => await OnExitAsync();
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void DisableAvaloniaDataAnnotationValidation()
    {
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }

    private static async Task OnExitAsync()
    {
        using var host = Host;
        await host.StopAsync();
    }

    public static void RestartApplication()
    {
        Process.Start(Process.GetCurrentProcess().MainModule?.FileName ?? throw new InvalidOperationException());
        Environment.Exit(0);
    }

    private static IHostBuilder CreateHostBuilder() =>
        new HostBuilder()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton(context.Configuration);
                services.AddSingleton<MainWindow>();
            });
}
