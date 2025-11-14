using DotnetShop.Identity.API.Models;
using System.Security.Claims;

namespace DotnetShop.Identity.API.Services
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(ApplicationUser user, IEnumerable<string> roles, IEnumerable<Claim> claims);
    }
}
