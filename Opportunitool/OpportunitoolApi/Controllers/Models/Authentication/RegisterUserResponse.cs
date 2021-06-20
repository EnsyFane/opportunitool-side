using OpportunitoolApi.Errors;
using System.Collections.Generic;
using System.Linq;

namespace OpportunitoolApi.Controllers.Models.Authentication
{
    public class RegisterUserResponse
    {
        public bool AccountCreated { get; set; }

        public IEnumerable<Error> Errors { get; set; }

        public RegisterUserResponse()
        {
            Errors = Enumerable.Empty<Error>();
        }
    }
}