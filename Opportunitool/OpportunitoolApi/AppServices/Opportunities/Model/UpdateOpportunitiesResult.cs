using OpportunitoolApi.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.AppServices.Opportunities.Model
{
    public class UpdateOpportunitiesResult
    {
        public IEnumerable<Opportunity> UpdatedOpportunities { get; }

        public IEnumerable<KeyValuePair<OpportunityUpdate, string>> InvalidOpportunities { get; }

        public IEnumerable<KeyValuePair<OpportunityUpdate, string>> NotFoundOpportunities { get; }

        public UpdateOpportunitiesResult(IEnumerable<Opportunity> updatedOpportunities, IEnumerable<KeyValuePair<OpportunityUpdate, string>> invalidOpportunities, IEnumerable<KeyValuePair<OpportunityUpdate, string>> notFoundOpportunities)
        {
            UpdatedOpportunities = updatedOpportunities;
            InvalidOpportunities = invalidOpportunities;
            NotFoundOpportunities = notFoundOpportunities;
        }

        public bool HasErrors()
        {
            return InvalidOpportunities.Any()
                || NotFoundOpportunities.Any();
        }
    }
}