using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace OpportunitoolApi.Controllers.Models.Authentication
{
    [SwaggerSchema(Required = new[] { nameof(UserName), nameof(Password) })]
    public class LogInUserRequest
    {
        [Required]
        [SwaggerSchema(Nullable = false)]
        public string UserName { get; set; }

        [Required]
        [SwaggerSchema(Nullable = false)]
        public string Password { get; set; }

        [Required]
        [SwaggerSchema(Nullable = false)]
        public bool RememberMe { get; set; }
    }
}