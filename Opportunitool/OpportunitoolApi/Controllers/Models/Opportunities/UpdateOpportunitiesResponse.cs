using OpportunitoolApi.AppServices.Opportunities.Model;
using OpportunitoolApi.Core.Models;
using OpportunitoolApi.Errors;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Controllers.Models.Opportunities
{
    public class UpdateOpportunitiesResponse
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }

        public IEnumerable<KeyValuePair<OpportunityUpdate, Error>> Errors { get; set; }

        public UpdateOpportunitiesResponse()
        {
            Opportunities = Enumerable.Empty<Opportunity>();
            Errors = Enumerable.Empty<KeyValuePair<OpportunityUpdate, Error>>();
        }
    }
}