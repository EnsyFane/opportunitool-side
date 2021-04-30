using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Opportunitool.Data;
using Opportunitool.Infrastructure.Mapper;
using System;

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _dbPassword = Configuration["DB:Pass"];

            services.AddDbContext<OpportunitoolContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("OpportunitoolConnection") + _dbPassword + ";"));

            services.AddControllers();

            services.AddSingleton<IMappingCoordinator, MappingCoordinator>();

            services.AddScoped<IOpportunityRepo, SqlOpportunityRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}