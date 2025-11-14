using DotnetShop.Identity.API.Dtos;
using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetShop.Identity.API.Services
{
    public class ProfileService(UserManager<ApplicationUser> userManager) : IProfileService
    {
        public async Task<UserDto> GetProfileAsync(string username)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user != null)
            {
                return new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    Gender = user.Gender,
                    PhoneNumber = user.PhoneNumber,
                    ShippingAddress = user.ShippingAddress,
                    BillingAddress = user.BillingAddress,
                    Payment = user.Payment,
                };
            }
            else
            {
                return new UserDto();
            }
        }
    }
}
