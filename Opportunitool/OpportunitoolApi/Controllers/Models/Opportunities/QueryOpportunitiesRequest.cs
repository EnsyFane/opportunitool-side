using Swashbuckle.AspNetCore.Annotations;

namespace OpportunitoolApi.Controllers.Models.Opportunities
{
    public class QueryOpportunitiesRequest
    {
        [SwaggerSchema(Nullable = true)]
        public string OpportunityFilter { get; set; }
    }
}