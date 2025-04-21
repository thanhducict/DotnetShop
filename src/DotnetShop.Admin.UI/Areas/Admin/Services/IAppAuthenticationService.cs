using DotnetShop.Admin.UI.Areas.Admin.Dtos;

namespace DotnetShop.Admin.UI.Areas.Admin.Services
{
    public interface IAppAuthenticationService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
    }
}
