using DotnetShop.Identity.API.Contants;
using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DotnetShop.Identity.API
{
    public static class SeedData
    {
        public static async Task AddSampleRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            if (!await roleManager.RoleExistsAsync(Roles.Customer))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Customer));
            }
        }

        public static async Task AddSampleUsers(UserManager<ApplicationUser> userManager)
        {
            if (await userManager.FindByNameAsync("admin") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "thanhduc.nguyen@dotnetshop.com",
                    FirstName = "Thanh Duc",
                    LastName = "Nguyen",
                    Gender = true,
                    AddressLine = "8/3 Street, Hai Ba Trung",
                    Country = "Vietnam",
                    State = "Hanoi",
                    ZipCode = "00084"
                };

                var result = await userManager.CreateAsync(user, "Cvbnm123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "admin");
                    await userManager.AddClaimsAsync(user, new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, Roles.Customer)
                    });
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
