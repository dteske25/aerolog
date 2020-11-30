using Aerolog.GraphQL;
using GraphQL;
using GraphQL.Server;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGraph(this IServiceCollection services)
        {
            services.AddScoped<IDependencyResolver>(x => new FuncDependencyResolver(x.GetRequiredService));
            services.AddScoped<IQueryResolver, QueryResolver>();

            services.AddScoped<Query>();
            services.AddScoped<Mutation>();
            services.AddScoped<AerologSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            }).AddGraphTypes(ServiceLifetime.Scoped);

            return services;
        }
    }
}
