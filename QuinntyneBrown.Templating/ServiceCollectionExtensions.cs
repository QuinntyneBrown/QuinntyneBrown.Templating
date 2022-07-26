using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace QuinntyneBrown.Templating
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTemplating(this IServiceCollection services, Action<TemplateLocatorOptions> options, ILogger logger)
        {
            services.Configure(options);
            services.AddSingleton<ITemplateLocator, TemplateLocator>();
            services.AddSingleton<ITemplateProcessor, LiquidTemplateProcessor>();
            services.AddSingleton<INamingConventionConverter, NamingConventionConverter>();
            services.AddSingleton<ITemplateRenderer, TemplateRenderer>();
            services.AddSingleton(logger);
            return services;
        }
    }
}
