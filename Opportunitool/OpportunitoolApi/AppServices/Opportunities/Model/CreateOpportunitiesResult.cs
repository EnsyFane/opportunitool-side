using OpportunitoolApi.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.AppServices.Opportunities.Model
{
    /// <summary>
    /// Class that contains information about the result of the create opportunities operation.
    /// </summary>
    public class CreateOpportunitiesResult
    {
        public IEnumerable<Opportunity> CreatedOpportunities { get; }

        public IEnumerable<OpportunityCreate> NotCreatedOpportunities { get; }

        public CreateOpportunitiesResult(IEnumerable<Opportunity> createdOpportunities, IEnumerable<OpportunityCreate> notCreatedOpportunities)
        {
            CreatedOpportunities = createdOpportunities;
            NotCreatedOpportunities = notCreatedOpportunities;
        }

        public bool HasErrors()
        {
            return NotCreatedOpportunities.Any();
        }
    }
}