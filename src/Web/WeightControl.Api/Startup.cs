using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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

            services
                .AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1.0", new OpenApiInfo
                    {
                        Title = "Weight Control API",
                        Version = "v1.0"
                    });
                });

            services.AddControllers();
            services.AddCors(opt => opt.AddDefaultPolicy(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1.0/swagger.json", "Api v1.0");
                options.RoutePrefix = "docs";
            });

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization(); 
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