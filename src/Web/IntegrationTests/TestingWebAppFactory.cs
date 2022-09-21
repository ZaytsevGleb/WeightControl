using IntegrationTests.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using WeightControl.Api;
using WeightControl.Application.Common.Interfaces;
using WeightControl.IntegrationTests.Infrastructure.Persistence;
using Xunit;

namespace WeightControl.IntegrationTests
{
    public abstract class TestingWebAppFactory : IAsyncLifetime
    {
        private DbConnection dbConnection;
        private IServiceScope dbScope;
        private WebApplicationFactory<Startup> application;


        protected IWeightControlApiClient ApiClient { get; private set; } = null!;
        protected IApplicationDbContext DbContext { get; private set; } = null!;

        public async Task InitializeAsync()
        {
            application = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Remove SqlServer DbContext
                        services
                            .RemoveAll(typeof(Persistence.ApplicationDbContext))
                            .RemoveAll(typeof(IApplicationDbContext))
                            .Remove(services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<Persistence.ApplicationDbContext>)));

                        // Add Sqlite DbContext
                        services.AddDbContext<ApplicationDbContext>(options =>
                        {
                            options.UseSqlite(CreateInMemoryDateBase());
                        });
                        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
                    });
                });

            dbScope = application.Services.CreateScope();
            var dbContext = dbScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.EnsureCreatedAsync();
            DbContext = dbContext;

            var httpClient = application.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOlsidXNlciIsImFkbWluIl0sImV4cCI6MTY2MzUyMTUwMSwiaXNzIjoiV2VpZ2h0Q29udHJvbCIsImF1ZCI6IldlaWdodENvbnRyb2wifQ.6Wn0PkVsHzpXH8HRpktV9g8JHUDVRh4HY3hOTZOouWQ");
            ApiClient = new WeightControlApiClient(string.Empty, httpClient);
        }

        public async Task DisposeAsync()
        {
            dbScope.Dispose();
            if (dbConnection.State != ConnectionState.Closed)
            {
                await dbConnection.DisposeAsync();
            }

            //HttpClient.Dispose();
            await application.DisposeAsync();
        }

        public DbConnection CreateInMemoryDateBase()
        {
            if (dbConnection == null)
            {
                dbConnection = new SqliteConnection("Filename=:memory:");
                dbConnection.Open();
            }

            return dbConnection;
        }
    }
}
