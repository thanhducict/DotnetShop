using DotnetShop.Identity.API.Dtos;
using DotnetShop.Identity.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Identity.API.Controllers
{
    [ApiController]
    [Route("{controller}/{action}")]
    public class AuthenticationController(IAppAuthenticationService authenticationService) : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var result = await authenticationService.Register(model);

            return result ? BadRequest() : Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto credential)
        {
            var response = new LoginResponseDto();

            if (credential == null || string.IsNullOrEmpty(credential.UserName) || string.IsNullOrEmpty(credential.Password))
            {
                response.Message = "Invalid client request";
                return BadRequest(response);
            }

            var loginResponse = await authenticationService.GetToken(credential);
            if (loginResponse.User == null)
            {
                response.Message = "Username or password is incorrect";
                return BadRequest(response);
            }

            response.User = loginResponse.User;
            response.Token = loginResponse.Token;
            response.Message = "Token retrieved successfully.";

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessful = await authenticationService.AssignRole(model.UserName, model.Role);

            if (!assignRoleSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignClaim([FromBody] RegistrationRequestDto model)
        {
            var assignClaimsSuccessful = await authenticationService.AssignClaims(model.UserName, model.Claims);

            if (!assignClaimsSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
