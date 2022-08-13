using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeightControl.Api.Infrastructure;
using WeightControl.Application;
using WeightControl.Persistence;

namespace WeightControl.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddApplicationDependensies()
                .AddPersistenceDependensies(configuration);

            services.AddControllers();
            services.AddCors(opt => opt.AddDefaultPolicy(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet(
                    "/",
                    async context =>
                    {
                        await context.Response.WriteAsync("Hello World!");
                    });

                endpoints.MapControllers();

            });
        }
    }
}