using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpportunitoolApi.AppServices.Opportunities;
using OpportunitoolApi.Infrastructure.Mapper;
using OpportunitoolApi.Persistence;
using OpportunitoolApi.Persistence.Repositories;
using System;
using System.IO;
using System.Reflection;

namespace OpportunitoolApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddDbContext(services);
            AddRepositories(services);
            AddFacades(services);
            ConfigureControllers(services);
            AddSwagger(services);
            AddUtilities(services);
        }

        private void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<OpportunitoolDbContext>(opt =>
            {
                string path = Directory.GetCurrentDirectory();
                string dbPath = Configuration.GetValue<string>("Db");
                if (dbPath.Contains(":"))
                {
                    path = dbPath;
                }
                else
                {
                    path += "\\" + dbPath;
                }
                var connectionString = $"Data Source={path};";
                opt.UseSqlite(connectionString);
            });
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IOpportunityRepository, EFOpportunityRepository>();
        }

        private void AddFacades(IServiceCollection services)
        {
            services.AddScoped<IOpportunityFacade, OpportunityFacade>();
        }

        private void ConfigureControllers(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowOrigin", options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                });
            });

            services.AddControllers();
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Opportunitool Api",
                    Version = "v1",
                    Description = "An API created in ASP.NET Core 5 for https://opportunitool.ro.",
                    Contact = new OpenApiContact
                    {
                        Name = "Tataran Stefan-George",
                        Email = string.Empty,
                        Url = new Uri("https://ensyfane.github.io/")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();
            });
        }

        private void AddUtilities(IServiceCollection services)
        {
            services.AddSingleton<IMappingCoordinator, MappingCoordinator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OpportunitoolApi v1"));
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}