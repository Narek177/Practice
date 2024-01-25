using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Practice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
                Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        public void ConfigureServices(IServiceCollection services)
        {
           
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync($"App name: {env.ApplicationName}. App running configuration: {env.EnvironmentName}"); });
            });
        }
    }
}
