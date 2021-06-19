using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

namespace OpportunitoolApi.Controllers.Models
{
    [SwaggerSchema(Required = new[] { nameof(OpportunityIds) })]
    public class GetOpportunitiesByIdsRequest
    {
        [SwaggerSchema(Nullable = false)]
        public IEnumerable<long> OpportunityIds { get; set; }
    }
}