using DotnetShop.WebApp.Models.Identity;

namespace DotnetShop.WebApp.Services
{
    public interface IIdentityService
    {
        Task<LoginResponseDto> LoginAsync(string userName, string password);
    }
}
