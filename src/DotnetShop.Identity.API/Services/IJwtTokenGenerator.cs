using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DotnetShop.Identity.API.Services
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(IdentityUser identityUser, IEnumerable<Claim> claims);
    }
}
