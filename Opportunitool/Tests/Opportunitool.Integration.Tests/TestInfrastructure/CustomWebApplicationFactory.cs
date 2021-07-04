using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpportunitoolApi;
using OpportunitoolApi.Persistence;
using System.Linq;

namespace Opportunitool.Integration.Tests.TestInfrastructure
{
    internal class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return WebHost.CreateDefaultBuilder(null)
                .UseStartup<Startup>();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<Startup>();
            builder.ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<OpportunitoolDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<OpportunitoolDbContext>(options =>
                    options.UseInMemoryDatabase("TestDB"));
            });

            base.ConfigureWebHost(builder);
        }
    }
}