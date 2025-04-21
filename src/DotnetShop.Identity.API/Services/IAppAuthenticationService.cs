using DotnetShop.Identity.API.Dtos;

namespace DotnetShop.Identity.API.Services
{
    public interface IAppAuthenticationService
    {
        Task<bool> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> GetToken(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string role);
        Task<bool> AssignClaims(string email, IEnumerable<ClaimDto> claimDtos);
    }
}
