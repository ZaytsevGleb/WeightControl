using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using WeightControl.Api.Infrastructure;
using WeightControl.Application;
using WeightControl.Application.Common.Options;
using WeightControl.Infrastructure;
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
            // Register application dependencies
            services
                .AddApplicationDependensies()
                .AddPersistenceDependensies(configuration)
                .AddInfrastructureDependensies(configuration);

            // Api configuration
            services
                .AddCors(opt => opt.AddDefaultPolicy(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()))
                .AddControllers();

            // Auth configuration
            var authOption = new AuthOptions();
            configuration.Bind(nameof(AuthOptions), authOption);
            services.Configure<AuthOptions>(configuration.GetSection(nameof(AuthOptions)));
            services.AddSingleton(Options.Create(authOption));

            services
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = authOption.Issuer,
                    ValidAudience = authOption.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOption.Secret))
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("user", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "user");
                });
                options.AddPolicy("admin", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "admin");
                });
            });

            // Swagger configuration
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "Weight Control API",
                    Version = "v1.0"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1.0/swagger.json", "Api v1.0");
                options.RoutePrefix = "docs";
            });

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseRouting();
            app.UseCors(builder => builder.WithMethods("POST"));
            app.UseAuthentication();
            app.UseAuthorization();
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