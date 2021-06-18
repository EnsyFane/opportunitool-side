using OpportunitoolApi.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.AppServices.Opportunities.Model
{
    public class UpdateOpportunitiesResult
    {
        public IEnumerable<Opportunity> UpdatedOpportunities { get; }

        public IEnumerable<OpportunityUpdate> NotUpdatedOpportunities { get; }

        public IEnumerable<OpportunityUpdate> NotFoundOpportunities { get; }

        public UpdateOpportunitiesResult(IEnumerable<Opportunity> updatedOpportunities, IEnumerable<OpportunityUpdate> notUpdatedOpportunities, IEnumerable<OpportunityUpdate> notFoundOpportunities)
        {
            UpdatedOpportunities = updatedOpportunities;
            NotUpdatedOpportunities = notUpdatedOpportunities;
            NotFoundOpportunities = notFoundOpportunities;
        }

        public bool HasErrors()
        {
            return NotUpdatedOpportunities.Any()
                || NotFoundOpportunities.Any();
        }
    }
}