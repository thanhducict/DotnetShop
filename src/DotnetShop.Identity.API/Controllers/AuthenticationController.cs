using DotnetShop.Identity.API.Dtos;
using DotnetShop.Identity.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Identity.API.Controllers
{
    [ApiController]
    [Route("{controller}/{action}")]
    public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var response = new ResponseDto();
            var message = await authenticationService.Register(model);

            if (!string.IsNullOrEmpty(message))
            {
                response.Message = message;
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto credential)
        {
            var response = new ResponseDto();

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

            response.Result = loginResponse;
            response.Message = "Token retrieved successfully.";

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var response = new ResponseDto();
            var assignRoleSuccessful = await authenticationService.AssignRole(model.Email, model.Role);

            if (!assignRoleSuccessful)
            {
                response.Message = "Error encountered";
                return BadRequest(response);
            }

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AssignClaim([FromBody] RegistrationRequestDto model)
        {
            var response = new ResponseDto();
            var result = await authenticationService.AssignClaims(model.Email, model.Claims);

            if (!result)
            {
                response.Result = result;
                response.Message = "Error encountered";

                return BadRequest(response);
            }

            response.Result = result;
            response.Message = "Claims assigned successfully.";

            return Ok(response);
        }
    }
}
