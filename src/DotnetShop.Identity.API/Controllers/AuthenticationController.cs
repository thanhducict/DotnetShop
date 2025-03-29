using DotnetShop.Identity.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace DotnetShop.Identity.API.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest credential)
        {
            //var user = ValidateUserCredentials(
            //    credential.Username,
            //    credential.Password);

            //if (user == null)
            //{
            //    return Unauthorized();
            //}

            //// Step 2: create a token
            //var securityKey = new SymmetricSecurityKey(
            //    Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            //var signingCredentials = new SigningCredentials(
            //    securityKey, SecurityAlgorithms.HmacSha256);

            //var claimsForToken = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, "admin"),
            //        new Claim(ClaimTypes.Email, "admin@email.com"),
            //        new Claim("Department", "HR"),
            //        new Claim("Admin", "true"),
            //        new Claim("HRManager", "true"),
            //        new Claim("EmploymentDate", "2024-01-25")
            //};

            //var jwtSecurityToken = new JwtSecurityToken(
            //    _configuration["Authentication:Issuer"],
            //    _configuration["Authentication:Audience"],
            //    claimsForToken,
            //    DateTime.UtcNow,
            //    DateTime.UtcNow.AddHours(1),
            //    signingCredentials);

            //var tokenToReturn = new JwtSecurityTokenHandler()
            //   .WriteToken(jwtSecurityToken);

            //return Ok(tokenToReturn);
            return View();
        }

        private T ValidateUserCredentials<T>(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
