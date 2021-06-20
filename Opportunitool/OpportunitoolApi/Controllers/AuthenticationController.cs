using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpportunitoolApi.Controllers.Models.Authentication;
using OpportunitoolApi.Errors;
using OpportunitoolApi.Infrastructure.Authentication;
using OpportunitoolApi.Infrastructure.Http;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpportunitoolApi.Controllers
{
    [ApiController]
    [Route("opportunitool/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<OpportunitoolUser> _userManager;
        private readonly SignInManager<OpportunitoolUser> _signInManager;

        public AuthenticationController(UserManager<OpportunitoolUser> userManager, SignInManager<OpportunitoolUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [RequireHttpsOrClose]
        [HttpPost("register")]
        [SwaggerOperation(
            Summary = "Registers a single user.",
            OperationId = "register",
            Tags = new[] { "Authentication" }
        )]
        [SwaggerResponse(200, "The registered user.", typeof(RegisterUserResponse))]
        [SwaggerResponse(424, "Services are unavailable.", typeof(RegisterUserResponse))]
        public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] RegisterUserRequest request)
        {
            // TODO: Add validation

            var user = new OpportunitoolUser
            {
                UserName = request.UserName,
                Email = request.Email
            };
            if (request.PhoneNumber != null)
            {
                user.PhoneNumber = request.PhoneNumber;
            }
            var registerResult = await _userManager.CreateAsync(user, request.Password);

            if (registerResult.Succeeded)
            {
                await SendVerification(user);

                var response = new RegisterUserResponse
                {
                    AccountCreated = true
                };

                if (_userManager.Options.SignIn.RequireConfirmedAccount)
                {
                    // Add rediret logic??
                    return Ok(response);
                }
                else
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(response);
                }
            }

            var errorResponse = GenerateRegistrationErrorResponse(registerResult);

            return ErrorResponse(errorResponse, StatusCodes.Status424FailedDependency);
        }

        private async Task SendVerification(OpportunitoolUser user)
        {
            // TODO: Add account verification. Enable this.
            //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            //var callbackUrl = Url.Page(
            //    "/Account/ConfirmEmail",
            //    pageHandler: null,
            //    values: new { area = "Identity", userId = user.Id, code = code },
            //    protocol: Request.Scheme
            //);

            //await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
            //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        }

        private static RegisterUserResponse GenerateRegistrationErrorResponse(IdentityResult registerResult)
        {
            var errorResponse = new RegisterUserResponse
            {
                AccountCreated = false
            };

            var errors = new List<Error>();

            foreach (var error in registerResult.Errors)
            {
                errors.Add(new Error
                {
                    External = true,
                    ErrorCode = error.Code,
                    ErrorMessage = error.Description
                });
            }

            errorResponse.Errors = errors;
            return errorResponse;
        }

        [Authorize]
        [RequireHttpsOrClose]
        [HttpPost("log-out")]
        [SwaggerOperation(
            Summary = "Logs out the currently logged in user.",
            OperationId = "log-out",
            Tags = new[] { "Authentication" }
        )]
        [SwaggerResponse(200, "The user is logged out.")]
        [SwaggerResponse(404, "Couldn't log out.")]
        public async Task<ActionResult> LogOutUser()
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }

        [AllowAnonymous]
        [RequireHttpsOrClose]
        [HttpPost("log-in")]
        [SwaggerOperation(
            Summary = "Attempts to log in a user.",
            OperationId = "log-in",
            Tags = new[] { "Authentication" }
        )]
        [SwaggerResponse(200, "The user is logged in.")]
        [SwaggerResponse(404, "Couldn't log in.")]
        public async Task<ActionResult> LogInUser([FromBody] LogInUserRequest request)
        {
            var logInResult = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, request.RememberMe, lockoutOnFailure: true);

            if (logInResult.Succeeded)
            {
                return Ok();
            }

            return NotFound();
        }

        private ActionResult<T> ErrorResponse<T>(T content, int statusCode)
        {
            var response = BadRequest(content);
            response.StatusCode = statusCode;
            return response;
        }
    }
}