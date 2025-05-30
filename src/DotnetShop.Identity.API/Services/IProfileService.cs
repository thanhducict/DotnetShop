using DotnetShop.Identity.API.Dtos;

namespace DotnetShop.Identity.API.Services
{
    public interface IProfileService
    {
        Task<UserDto> GetProfileAsync(string username);
    }
}
