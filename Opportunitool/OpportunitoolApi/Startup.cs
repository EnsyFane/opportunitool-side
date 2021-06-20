using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OpportunitoolApi.AppServices.Opportunities;
using OpportunitoolApi.Infrastructure.Authentication;
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
            AddAuthentication(services);
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

        private static void AddAuthentication(IServiceCollection services)
        {
            services.AddIdentity<OpportunitoolUser, IdentityRole>()
                .AddEntityFrameworkStores<OpportunitoolDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 2;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IOpportunityRepository, EFOpportunityRepository>();
        }

        private static void AddFacades(IServiceCollection services)
        {
            services.AddScoped<IOpportunityFacade, OpportunityFacade>();
        }

        private static void ConfigureControllers(IServiceCollection services)
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

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Opportunitool Api",
                    Version = "v1",
                    Description = $"An API created in ASP.NET Core 5 for { new Uri("https://opportunitool.ro.") }",
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

        private static void AddUtilities(IServiceCollection services)
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}