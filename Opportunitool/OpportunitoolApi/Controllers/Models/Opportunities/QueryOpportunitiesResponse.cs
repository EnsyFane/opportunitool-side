using OpportunitoolApi.Core.Models;
using System.Collections.Generic;

namespace OpportunitoolApi.Controllers.Models.Opportunities
{
    public class QueryOpportunitiesResponse
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }

        public string Error { get; set; }
    }
}