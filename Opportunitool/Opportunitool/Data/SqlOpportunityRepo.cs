using Opportunitool.Models;
using System.Collections.Generic;
using System.Linq;

namespace Opportunitool.Data
{
    public class SqlOpportunityRepo : IOpportunityRepo
    {
        private readonly OpportunitoolContext _context;

        public SqlOpportunityRepo(OpportunitoolContext context)
        {
            _context = context;
        }

        public IEnumerable<Opportunity> GetAllOpportunities()
        {
            return _context.Opportunities.ToList();
        }

        public Opportunity GetOpportunityById(int id)
        {
            return _context.Opportunities.FirstOrDefault(p => p.Id == id);
        }
    }
}