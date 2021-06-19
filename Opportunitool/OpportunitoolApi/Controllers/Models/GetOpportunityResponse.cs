using OpportunitoolApi.Core.Models;
using OpportunitoolApi.Errors;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Controllers.Models
{
    public class GetOpportunityResponse
    {
        public Opportunity Opportunity { get; set; }

        public IEnumerable<Error> Errors { get; set; }

        public GetOpportunityResponse()
        {
            Opportunity = null;
            Errors = Enumerable.Empty<Error>();
        }
    }
}