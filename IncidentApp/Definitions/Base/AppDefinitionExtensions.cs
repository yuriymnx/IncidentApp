using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IncidentApp.Definitions.Base;

public static class AppDefinitionExtensions
{
    private static bool Predicate(Type type) => type is { IsAbstract: false, IsInterface: false } && typeof(AppDefinition).IsAssignableFrom(type);

    public static IHostBuilder AddDefinitions(this IHostBuilder builder, params Type[] entryPointsAssembly)
    {
        return builder.ConfigureServices((context, collection) => collection.AddDefinitions(context, entryPointsAssembly));
    }

    private static void AddDefinitions(this IServiceCollection services, HostBuilderContext context, params Type[] entryPointsAssembly)
    {
        var logger = services.BuildServiceProvider().GetRequiredService<ILogger<AppDefinition>>();
        var addedDefinitions = new List<IAppDefinition>();

        foreach (var type in entryPointsAssembly)
        {
            var foundedDefinitions = type.Assembly.ExportedTypes
                .Where(Predicate)
                .Select(Activator.CreateInstance)
                .Cast<IAppDefinition>()
                .OrderByDescending(definition => definition.OrderIndex)
                .ToList();

            var enabledDefinitions = foundedDefinitions.Where(definition => definition.Enabled).ToList();

            if (logger.IsEnabled(LogLevel.Debug))
            {
                logger.LogDebug("[AppDefinitions] Founded: {AppDefinitionsCountTotal}. Enabled: {AppDefinitionsCountEnabled}",
                    foundedDefinitions.Count, enabledDefinitions.Count);

                logger.LogDebug("[AppDefinitions] Registered [{Total}]",
                    string.Join(", ", enabledDefinitions.Select(definition => definition.GetType().Name)));
            }

            addedDefinitions.AddRange(enabledDefinitions);
        }

        addedDefinitions.ForEach(definition => definition.ConfigureServices(services, context));

        services.AddSingleton((IReadOnlyCollection<IAppDefinition>)addedDefinitions);
    }

    public static async Task UseDefinitions(this IHost host)
    {
        var logger = host.Services.GetRequiredService<ILogger<AppDefinition>>();

        var definitions = host.Services.GetRequiredService<IReadOnlyCollection<IAppDefinition>>()
            .Where(definition => definition.Enabled)
            .OrderByDescending(definition => definition.OrderIndex)
            .ToList();

        foreach (var definition in definitions)
            await definition.ConfigureApplication(host);

        logger.LogDebug("[AppDefinitions] Total application definitions configured {Count}", definitions.Count);

        logger.LogDebug("[AppDefinitions] Used [{Total}]",
            string.Join(", ", definitions.Select(definition => definition.GetType().Name)));
    }
}