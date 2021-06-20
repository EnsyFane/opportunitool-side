using OpportunitoolApi.AppServices.Opportunities.Model;
using OpportunitoolApi.Core.Models;
using OpportunitoolApi.Errors;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Controllers.Models.Opportunities
{
    public class CreateOpportunitiesResponse
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }

        public IEnumerable<KeyValuePair<OpportunityCreate, Error>> Errors { get; set; }

        public CreateOpportunitiesResponse()
        {
            Opportunities = Enumerable.Empty<Opportunity>();
            Errors = Enumerable.Empty<KeyValuePair<OpportunityCreate, Error>>();
        }
    }
}