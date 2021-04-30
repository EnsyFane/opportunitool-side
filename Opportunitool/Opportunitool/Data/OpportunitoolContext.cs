using Microsoft.EntityFrameworkCore;
using Opportunitool.Models;

namespace Opportunitool.Data
{
    public class OpportunitoolContext : DbContext
    {
        public OpportunitoolContext(DbContextOptions<OpportunitoolContext> opt) : base(opt)
        {
        }

        public DbSet<Opportunity> Opportunities { get; set; }
    }
}