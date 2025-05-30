using DotnetShop.Identity.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Identity.API.Controllers
{
    [ApiController]
    [Route("{controller}/{action}")]
    public class ProfileController(IProfileService profileService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProfile(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Username cannot be null or empty.");
            }

            var userProfile = await profileService.GetProfileAsync(username);

            if (userProfile == null)
            {
                return NotFound($"User with username '{username}' not found.");
            }

            return Ok(userProfile);
        }
    }
}
