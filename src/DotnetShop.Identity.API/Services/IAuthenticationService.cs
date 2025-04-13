using DotnetShop.Identity.API.Dtos;

namespace DotnetShop.Identity.API.Services
{
    public interface IAuthenticationService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
