
using Aerolog.GraphQL;
using GraphQL.Server;
using Microsoft.Extensions.Logging;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGraph(this IServiceCollection services)
        {
            services.AddScoped<IQueryResolver, QueryResolver>();

            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<AerologSchema>();


            services.AddGraphQL((options, provider) =>
            {
                options.EnableMetrics = true;
                //var logger = provider.GetRequiredService<ILogger>();
                //options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
            })
                // It is required when both GraphQL HTTP and GraphQL WebSockets middlewares are mapped to the same endpoint (by default 'graphql').
                .AddDefaultEndpointSelectorPolicy()
                // Add required services for GraphQL request/response de/serialization
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddWebSockets() // Add required services for web socket support
                .AddDataLoader() // Add required services for DataLoader support
                .AddGraphTypes(typeof(AerologSchema), ServiceLifetime.Scoped);

            return services;
        }
    }
}
