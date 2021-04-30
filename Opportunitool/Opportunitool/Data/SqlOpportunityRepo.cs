using Opportunitool.Models;
using System;
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

        public void CreateOpportunity(Opportunity opportunity)
        {
            if (opportunity == null)
            {
                throw new ArgumentNullException(nameof(opportunity));
            }

            _context.Opportunities.Add(opportunity);
        }

        public IEnumerable<Opportunity> GetAllOpportunities()
        {
            return _context.Opportunities.ToList();
        }

        public Opportunity GetOpportunityById(int id)
        {
            return _context.Opportunities.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateOpportunity(Opportunity opportunity)
        {
        }
    }
}