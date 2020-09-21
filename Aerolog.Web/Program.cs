using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Aerolog.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string port = Environment.GetEnvironmentVariable("PORT");

            var builder = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

            if (port != null)
            {
                // This seems to work for GCP so far
                builder = builder.UseUrls($"http://0.0.0.0:{port}");
            }

            return builder;
        }
    }
}
