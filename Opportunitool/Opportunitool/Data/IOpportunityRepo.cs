using Opportunitool.Models;
using System.Collections.Generic;

namespace Opportunitool.Data
{
    public interface IOpportunityRepo
    {
        bool SaveChanges();

        IEnumerable<Opportunity> GetAllOpportunities();

        Opportunity GetOpportunityById(int id);

        void CreateOpportunity(Opportunity opportunity);
    }
}