using OpportunitoolApi.AppServices.Opportunities.Model;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpportunitoolApi.Controllers.Models.Opportunities
{
    [SwaggerSchema(Required = new[] { nameof(Opportunities) })]
    public class UpdateOpportunitiesRequest
    {
        [Required]
        [SwaggerSchema(Nullable = false)]
        public IEnumerable<OpportunityUpdate> Opportunities { get; set; }
    }
}