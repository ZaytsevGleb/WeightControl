using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeightControl.BusinessLogic.Services;
using WeightControl.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using WeightControl.DataAccess;

namespace WeightControl.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDBContext>(options =>
            {
                /*options.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information);*/
                options.UseSqlServer(connection);
            });

            services.AddControllersWithViews();

            services.AddControllers();
            services.AddScoped<IAuthService,AuthService>();
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            
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