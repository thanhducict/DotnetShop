using DotnetShop.Identity.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotnetShop.Identity.API.Services
{
    public class JwtTokenGenerator(JwtOptions jwtOptions) : IJwtTokenGenerator
    {
        public string GenerateToken(ApplicationUser user, IEnumerable<string> roles, IEnumerable<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var claim in claims)
            {
                claimsForToken.Add(claim);
            }

            var jwtSecurityToken = new JwtSecurityToken(
                jwtOptions.Issuer,
                jwtOptions.Audience,
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            return tokenToReturn;
        }
    }
}
