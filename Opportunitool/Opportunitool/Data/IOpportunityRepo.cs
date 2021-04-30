using Opportunitool.Models;
using System.Collections.Generic;

namespace Opportunitool.Data
{
    public interface IOpportunityRepo
    {
        IEnumerable<Opportunity> GetAllOpportunities();

        Opportunity GetOpportunityById(int id);
    }
}