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
                    PhoneNumber = "0987333333"
                };

                var result = await userManager.CreateAsync(user, "Cvbnm123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin);
                    await userManager.AddClaimsAsync(user, new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email)
                    });
                }
            }

            if (await userManager.FindByNameAsync("rooney") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "rooney",
                    FirstName = "Wayne",
                    LastName = "Rooney",
                    Email = "wayne.rooney@manutd.com",
                    Gender = true,
                    PhoneNumber = "0987555555",
                    ShippingAddress = new Address
                    {
                        FirstName = "Wayne",
                        LastName = "Rooney",
                        AddressLine = "Old Trafford",
                        Country = "England",
                        EmailAddress = "wayne.rooney@manutd.com",
                        State = "England",
                        ZipCode = "M16 0RA"
                    },
                    BillingAddress = new Address
                    {
                        FirstName = "Wayne",
                        LastName = "Rooney",
                        AddressLine = "Old Trafford",
                        Country = "England",
                        EmailAddress = "wayne.rooney@manutd.com",
                        State = "England",
                        ZipCode = "M16 0RA"
                    },
                    Payment = new Payment
                    {
                        CardName = "Wayne Rooney",
                        CardNumber = "1234567890123456",
                        Expiration = "12/25",
                        CVV = "123",
                        PaymentMethod = 1
                    }
                };

                var result = await userManager.CreateAsync(user, "Cvbnm123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Customer);
                    await userManager.AddClaimsAsync(user, new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email)
                    });
                }
            }

            if (await userManager.FindByNameAsync("scholes") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "scholes",
                    FirstName = "paul",
                    LastName = "scholes",
                    Email = "paul.scholes@manutd.com",
                    Gender = true,
                    PhoneNumber = "0987666666",
                    ShippingAddress = new Address
                    {
                        FirstName = "Paul",
                        LastName = "Scholes",
                        AddressLine = "Old Trafford",
                        Country = "England",
                        EmailAddress = "paul.scholes@manutd.com",
                        State = "England",
                        ZipCode = "M16 0RA"
                    },
                    BillingAddress = new Address
                    {
                        FirstName = "Paul",
                        LastName = "Scholes",
                        AddressLine = "Old Trafford",
                        Country = "England",
                        EmailAddress = "paul.scholes@manutd.com",
                        State = "England",
                        ZipCode = "M16 0RA"
                    },
                    Payment = new Payment
                    {
                        CardName = "Paul Scholes",
                        CardNumber = "1234567890123456",
                        Expiration = "12/25",
                        CVV = "123",
                        PaymentMethod = 1
                    },
                };

                var result = await userManager.CreateAsync(user, "Cvbnm123@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Customer);
                    await userManager.AddClaimsAsync(user, new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email)
                    });
                }
            }
        }
    }
}
