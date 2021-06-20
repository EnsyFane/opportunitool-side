using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OpportunitoolApi.Core.Models;
using OpportunitoolApi.Infrastructure.Authentication;

namespace OpportunitoolApi.Persistence
{
    public class OpportunitoolDbContext : IdentityDbContext<OpportunitoolUser>
    {
        public DbSet<Opportunity> Opportunities { get; set; }

        public OpportunitoolDbContext(DbContextOptions<OpportunitoolDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}