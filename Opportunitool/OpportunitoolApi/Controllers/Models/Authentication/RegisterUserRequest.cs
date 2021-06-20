using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace OpportunitoolApi.Controllers.Models.Authentication
{
    [SwaggerSchema(Required = new[] { nameof(UserName), nameof(Email), nameof(Password) })]
    public class RegisterUserRequest
    {
        [Required]
        [SwaggerSchema(Nullable = false)]
        public string UserName { get; set; }

        [Required]
        [SwaggerSchema(Nullable = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [SwaggerSchema(Nullable = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [SwaggerSchema(Nullable = false)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}