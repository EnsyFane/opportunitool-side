using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.AppServices.Opportunities.Model
{
    public class DeleteOpportunitiesResult
    {
        public IEnumerable<string> DeletedOpportunities { get; }

        public IEnumerable<string> InvalidOpportunities { get; }

        public IEnumerable<string> NotFoundOpportunities { get; }

        public DeleteOpportunitiesResult(IEnumerable<string> updatedOpportunities, IEnumerable<string> invalidOpportunities, IEnumerable<string> notFoundOpportunities)
        {
            DeletedOpportunities = updatedOpportunities;
            InvalidOpportunities = invalidOpportunities;
            NotFoundOpportunities = notFoundOpportunities;
        }

        public bool HasErrors()
        {
            return InvalidOpportunities.Any()
                || NotFoundOpportunities.Any(); ;
        }
    }
}