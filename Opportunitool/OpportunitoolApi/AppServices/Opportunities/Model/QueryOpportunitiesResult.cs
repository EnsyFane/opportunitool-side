using OpportunitoolApi.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.AppServices.Opportunities.Model
{
    public class QueryOpportunitiesResult
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }

        public string Error { get; set; }

        public QueryOpportunitiesResult()
        {
            Opportunities = Enumerable.Empty<Opportunity>();
            Error = string.Empty;
        }

        public bool HasErrors()
        {
            return !string.IsNullOrEmpty(Error);
        }
    }
}