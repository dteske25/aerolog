using Aerolog.GraphQL;
using GraphiQl;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddAccessors(GetMongoDBConnectionString(), Configuration["MongoDB:Database"]);
            services.AddEngines();
            services.AddGraph();
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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

            // app.UseGraphQL<AerologSchema, AerologGraphQLMiddleware<AerologSchema>>();
            app.UseGraphQL<AerologSchema>();
            app.UseGraphiQl("/graphql-ui");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

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
