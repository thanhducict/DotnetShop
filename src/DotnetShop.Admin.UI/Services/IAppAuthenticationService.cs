using DotnetShop.Admin.UI.Dtos;

namespace DotnetShop.Admin.UI.Services
{
    public interface IAppAuthenticationService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
    }
}
