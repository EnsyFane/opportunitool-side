using OpportunitoolApi.AppServices.Opportunities.Model;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpportunitoolApi.Controllers.Models
{
    [SwaggerSchema(Required = new[] { nameof(Opportunities) })]
    public class CreateOpportunitiesRequest
    {
        [Required]
        [SwaggerSchema(Nullable = false)]
        public IEnumerable<OpportunityCreate> Opportunities { get; set; }
    }
}