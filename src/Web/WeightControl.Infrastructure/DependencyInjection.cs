using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Infrastructure.Services;

namespace WeightControl.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructureDependensies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}