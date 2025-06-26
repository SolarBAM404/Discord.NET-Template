using DiscordNetTemplate.Common.Options;
using Fergun.Interactive;
using Microsoft.Extensions.DependencyInjection;

namespace DiscordNetTemplate.Extensions;

internal static class ServiceCollectionExtensions
{
    
    
    public static void AddInteractiveService(this IServiceCollection services, Action<InteractiveConfig>? action)
    {
        InteractiveConfig config = new InteractiveConfig();
        action?.Invoke(config);

        services.AddSingleton(config);
        services.AddSingleton<InteractiveService>();
    }
    
    
    public static void AddNamedOptions<TNamedOptions>(this IServiceCollection services)
        where TNamedOptions : class, INamedOptions
    {
        services.AddOptions<TNamedOptions>()
            .BindConfiguration(TNamedOptions.GetSectionName())
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}