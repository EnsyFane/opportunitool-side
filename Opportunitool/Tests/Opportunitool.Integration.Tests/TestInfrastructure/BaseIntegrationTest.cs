using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OpportunitoolApi;
using OpportunitoolApi.Persistence;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Opportunitool.Integration.Tests.TestInfrastructure
{
    public class BaseIntegrationTest
    {
        protected HttpClient _client;
        protected readonly WebApplicationFactory<Startup> _factory;

        public BaseIntegrationTest()
        {
            _factory = new CustomWebApplicationFactory()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(dbc => dbc.ServiceType == typeof(OpportunitoolDbContext));
                        services.Remove(descriptor);
                        services.AddDbContext<OpportunitoolDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDbForTesting");
                        });
                    });
                });
            _client = _factory.CreateClient();
            var requestHeaders = _client.DefaultRequestHeaders;

            if (requestHeaders.Accept == null || !requestHeaders.Accept.Any(m => m.MediaType == "application/json"))
            {
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
    }
}