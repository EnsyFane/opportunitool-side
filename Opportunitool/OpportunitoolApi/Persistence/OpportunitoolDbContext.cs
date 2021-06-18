using Microsoft.EntityFrameworkCore;
using OpportunitoolApi.Core.Models;

namespace OpportunitoolApi.Persistence
{
    public class OpportunitoolDbContext : DbContext
    {
        public DbSet<Opportunity> Opportunities { get; set }

        public OpportunitoolDbContext(DbContextOptions<OpportunitoolDbContext> opt) : base(opt)
        {
        }
    }
}