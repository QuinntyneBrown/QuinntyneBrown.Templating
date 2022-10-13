using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace QuinntyneBrown.Templating;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTemplating(this IServiceCollection services, Action<TemplateLocatorOptions> options)
    {
        services.Configure(options);
        services.AddSingleton<ITemplateLocator, TemplateLocator>();
        services.AddSingleton<ITemplateProcessor, LiquidTemplateProcessor>();
        services.AddSingleton<INamingConventionConverter, NamingConventionConverter>();
        services.AddSingleton<ITemplateRenderer, TemplateRenderer>();
        return services;
    }
}
