using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Opportunitool.Data;
using Opportunitool.Infrastructure.Mapper;

namespace Opportunitool
{
    public class Startup
    {
        private string _dbPassword = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _dbPassword = Configuration["DB:Pass"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.Audience = Configuration["ADD:ResourceId"];
                    opt.Authority = $"{Configuration["AAD:InstanceId"]}{Configuration["ADD:TenantId"]}";
                });

            services.AddDbContext<OpportunitoolContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("OpportunitoolConnection") + _dbPassword + ";"));

            services.AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddSingleton<IMappingCoordinator, MappingCoordinator>();

            services.AddScoped<IOpportunityRepo, SqlOpportunityRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}