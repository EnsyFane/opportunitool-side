using OpportunitoolApi.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Controllers.Models.Opportunities
{
    public class GetOpportunitiesResponse
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }

        public GetOpportunitiesResponse()
        {
            Opportunities = Enumerable.Empty<Opportunity>();
        }
    }
}