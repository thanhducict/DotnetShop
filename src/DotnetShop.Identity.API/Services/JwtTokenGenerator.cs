using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DotnetShop.Identity.API.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(IdentityUser identityUser, IEnumerable<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
