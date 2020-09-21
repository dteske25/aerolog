using Aerolog.Engines;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEngines(this IServiceCollection services)
        {
            services.AddTransient<ISeriesEngine, SeriesEngine>();
            services.AddTransient<IMissionEngine, MissionEngine>();
            services.AddTransient<ILogEngine, LogEngine>();

            return services;
        }
    }
}
