using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DotnetShop.Identity.API
{
    public static class SeedData
    {
        private static async Task AddSampleUsers(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    FirstName = "Thanh Duc",
                    LastName = "Nguyen",
                    Email = "thanhduc.nguyen@dotnetshop.com"
                };

                var result = await userManager.CreateAsync(user, "Cvbnm123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "admin");
                    await userManager.AddClaimsAsync(user, new List<Claim>());
                }
            }

            if (await userManager.FindByNameAsync("scholes") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "scholes",
                    FirstName = "Paul",
                    LastName = "Scholes",
                    Email = "paul.scholes@manutd.com"
                };

                var result = await userManager.CreateAsync(user, "Cvbnm123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "customer");
                }
            }

            if (await userManager.FindByNameAsync("rooney") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "rooney",
                    FirstName = "Wayne",
                    LastName = "Rooney",
                    Email = "wayne.rooney@manutd.com"
                };

                var result = await userManager.CreateAsync(user, "Cvbnm123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "customer");
                }
            }

            if (await userManager.FindByNameAsync("scholes") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "scholes",
                    FirstName = "paul",
                    LastName = "scholes",
                    Email = "paul.scholes@manutd.com"
                };

                var result = await userManager.CreateAsync(user, "Cvbnm123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "customer");
                }
            }
        }
    }
}
