using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.AppServices.Opportunities.Model
{
    public class DeleteOpportunitiesResult
    {
        public IEnumerable<long> DeletedOpportunities { get; }

        public IEnumerable<long> NotFoundOpportunities { get; }

        public DeleteOpportunitiesResult(IEnumerable<long> updatedOpportunities, IEnumerable<long> notFoundOpportunities)
        {
            DeletedOpportunities = updatedOpportunities;
            NotFoundOpportunities = notFoundOpportunities;
        }

        public bool HasErrors()
        {
            return NotFoundOpportunities.Any();
        }
    }
}