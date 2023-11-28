using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TeamVisionGR.API.Models.Authentication;
using TeamVisionGR.Application.Dtos.Authentication;
using TeamVisionGR.Application.Services;
using TeamVisionGR.Application.Services.Authentication;

namespace TeamVisionGR.API.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthenticationController : TeamVisionGRController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserActivationService _userActivationService;

        public AuthenticationController(
            IAuthenticationService authenticationService,
            IUserActivationService userActivationService)
        {
            _authenticationService = authenticationService;
            _userActivationService = userActivationService;
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestModel model)
        {
            SignUpRequestDto userSignUpRequestDto = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password
            };

            var response = await _authenticationService.CreateUserAsync(userSignUpRequestDto);

            return Response(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestModel model)
        {
            SignInRequestDto userSignInRequestDto = new()
            {
                Email = model.Email,
                Password = model.Password
            };

            var response = await _authenticationService.AuthenticateUserAsync(userSignInRequestDto);

            return Response(response);
        }

        [HttpPost("Activation/{activationId}")]
        public async Task<IActionResult> ActivateUser(Guid activationId)
        {
            var response = await _userActivationService.ActivateUser(activationId);

            return Response(response);
        }
    }
}