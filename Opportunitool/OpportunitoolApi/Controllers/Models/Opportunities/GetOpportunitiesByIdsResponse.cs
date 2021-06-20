using OpportunitoolApi.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Controllers.Models.Opportunities
{
    public class GetOpportunitiesByIdsResponse
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }

        public IEnumerable<long> NotFound { get; set; }

        public GetOpportunitiesByIdsResponse()
        {
            Opportunities = Enumerable.Empty<Opportunity>();
            NotFound = Enumerable.Empty<long>();
        }
    }
}