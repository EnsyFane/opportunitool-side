using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpportunitoolApi.Controllers.Models
{
    [SwaggerSchema(Required = new[] { nameof(OpportunityIds) })]
    public class GetOpportunitiesByIdsRequest
    {
        [Required]
        [SwaggerSchema(Nullable = false)]
        public IEnumerable<long> OpportunityIds { get; set; }
    }
}