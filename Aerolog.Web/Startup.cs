using Aerolog.GraphQL;
using Aerolog.GraphQL.Infrastructure;
using GraphiQl;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aerolog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddAccessors(GetMongoDBConnectionString(), Configuration["MongoDB:Database"]);
            services.AddEngines();
            services.AddGraph();

            services.AddControllers();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app/build";
            });

            //services.Configure<KestrelServerOptions>(options =>
            //{
            //    options.AllowSynchronousIO = true;
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseWebSockets();
            app.UseRouting();

            // app.UseGraphQL<AerologSchema, AerologGraphQLMiddleware<AerologSchema>>();
            app.UseGraphQL<AerologSchema>();
            app.UseGraphiQl("/graphql-ui");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");

                // map websocket middleware for ChatSchema at default path /graphql
                endpoints.MapGraphQLWebSockets<AerologSchema>();

                // map HTTP middleware for ChatSchema at default path /graphql
                endpoints.MapGraphQL<AerologSchema, GraphQLHttpMiddlewareWithLogs<AerologSchema>>();

                // map GraphiQL middleware at default path /ui/graphiql with default options
                endpoints.MapGraphQLGraphiQL();

            });

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});
           
            app.UseSpa(spa =>
            {
                // Only used in development
                spa.Options.SourcePath = "client-app";

                if (env.IsDevelopment())
                {
                    string spaClientUrl = Configuration["SpaClient"];
                    spa.UseProxyToSpaDevelopmentServer(spaClientUrl);
                }
            });
        }

        private string GetMongoDBConnectionString()
        {
            return $"mongodb://{Configuration["MongoDB:User"]}:{Configuration["MongoDB:Password"]}@{Configuration["MongoDB:Host"]}:{Configuration["MongoDB:Port"]}/{Configuration["MongoDB:AuthDatabase"]}";
        }
    }
}
