using System;
using System.Threading.Tasks;
using Aerolog.Uploader.SeriesLoader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aerolog.Uploader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            // Application code should start here.
            var scope = host.Services.CreateScope();
            await SetupAllSeries(scope);

            Console.WriteLine("Uploading Completed!");
            Console.ReadLine();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddAccessors(GetMongoDBConnectionString(context), context.Configuration["MongoDB:Database"]);
                    services.AddEngines();
                    services.AddTransient<ISeriesLoader, ApolloLoader>();
                    services.AddTransient<ISeriesLoader, GeminiLoader>();
                    services.BuildServiceProvider();
                });

        static async Task SetupAllSeries(IServiceScope scope)
        {
            var seriesLoaders = scope.ServiceProvider.GetServices<ISeriesLoader>();
            foreach (var seriesLoader in seriesLoaders)
            {
                var series = await seriesLoader.GetOrCreateSeries();
                Console.WriteLine($"Series: {series.SeriesName} - {series.Id}");
            }
        }

        private static string GetMongoDBConnectionString(HostBuilderContext context)
        {
            return $"mongodb://{context.Configuration["MongoDB:User"]}:{context.Configuration["MongoDB:Password"]}@{context.Configuration["MongoDB:Host"]}:{context.Configuration["MongoDB:Port"]}/{context.Configuration["MongoDB:AuthDatabase"]}";
        }
    }
}
