using DotnetShop.Identity.API.Dtos;
using DotnetShop.Identity.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Identity.API.Controllers
{
    public class AuthenticationController(IAuthenticationService authenticationService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto credential)
        {
            var response = new ResponseDto();

            if (credential == null || string.IsNullOrEmpty(credential.UserName) || string.IsNullOrEmpty(credential.Password))
            {
                response.IsSuccess = false;
                response.Message = "Invalid client request";
                return BadRequest(response);
            }

            var loginResponse = await authenticationService.Login(credential);
            if (loginResponse.User == null)
            {
                response.IsSuccess = false;
                response.Message = "Username or password is incorrect";
                return BadRequest(response);
            }

            response.Result = loginResponse;

            return Ok(response);
        }
    }
}
