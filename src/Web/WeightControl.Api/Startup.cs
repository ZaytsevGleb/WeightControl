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
using WeightControl.Api.Middlewares;
using FluentValidation;
using WeightControl.Domain.Entities;
using WeightControl.BusinessLogic.Validators;
using WeightControl.Api.Views;

namespace WeightControl.Api
{
    public class Startup
    {
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
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(connection);
            });

            services.AddControllersWithViews();
            services.AddScoped <IValidator<ProductDto>, ProductPostValidator>();
            services.AddControllers();
            services.AddScoped<IAuthService,AuthService>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddCors(opt => opt.AddDefaultPolicy(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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