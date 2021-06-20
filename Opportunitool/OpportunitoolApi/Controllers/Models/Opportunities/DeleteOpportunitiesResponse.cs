using OpportunitoolApi.Errors;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Controllers.Models.Opportunities
{
    public class DeleteOpportunitiesResponse
    {
        public IEnumerable<long> DeletedOpportunityIds { get; set; }

        public IEnumerable<KeyValuePair<long, Error>> Errors { get; set; }

        public DeleteOpportunitiesResponse()
        {
            DeletedOpportunityIds = Enumerable.Empty<long>();
            Errors = Enumerable.Empty<KeyValuePair<long, Error>>();
        }
    }
}