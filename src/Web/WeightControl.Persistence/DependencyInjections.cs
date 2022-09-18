using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Persistence.Repositories;

namespace WeightControl.Persistence
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPersistenceDependensies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IApplicationDbContext>(provider => 
                provider.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
