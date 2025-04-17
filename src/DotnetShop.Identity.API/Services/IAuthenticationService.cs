using DotnetShop.Identity.API.Dtos;
using System.Security.Claims;

namespace DotnetShop.Identity.API.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> GetToken(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string role);
        Task<bool> AssignClaims(string email, IEnumerable<ClaimDto> claimDtos);
    }
}
