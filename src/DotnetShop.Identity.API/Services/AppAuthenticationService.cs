using DotnetShop.Identity.API.Dtos;
using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Security.Claims;

namespace DotnetShop.Identity.API.Services
{
    public class AppAuthenticationService(
        IdentityApiDbContext identityApiDbContext,
        IJwtTokenGenerator bearerTokenGenerator,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager) : IAppAuthenticationService
    {
        public async Task<bool> Register(RegistrationRequestDto registrationRequestDto)
        {
            var user = new ApplicationUser
            {
                UserName = registrationRequestDto.UserName,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                FirstName = registrationRequestDto.Firstname,
                LastName = registrationRequestDto.Lastname,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            var result = await userManager.CreateAsync(user, registrationRequestDto.Password);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(registrationRequestDto.Role))
                {
                    if (await roleManager.RoleExistsAsync(registrationRequestDto.Role))
                    {
                        await userManager.AddToRoleAsync(user, registrationRequestDto.Role);
                    }
                    else
                    {
                        await roleManager.CreateAsync(new IdentityRole(registrationRequestDto.Role));
                        await userManager.AddToRoleAsync(user, registrationRequestDto.Role);
                    }
                }

                if (registrationRequestDto.Claims != null && registrationRequestDto.Claims.Count != 0)
                {
                    foreach (var claim in registrationRequestDto.Claims)
                    {
                        var claimType = claim.Type;
                        var claimValue = claim.Value;
                        if (!string.IsNullOrEmpty(claimType) && !string.IsNullOrEmpty(claimValue))
                        {
                            var newClaim = new Claim(claimType, claimValue);
                            await userManager.AddClaimAsync(user, newClaim);
                        }
                    }
                }
            }

            return true;
        }

        public async Task<LoginResponseDto> GetToken(LoginRequestDto loginRequestDto)
        {
            var user = identityApiDbContext.Users.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValid = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto { User = new UserDto(), Token = string.Empty };
            }

            var roles = await userManager.GetRolesAsync(user);
            var claims = await userManager.GetClaimsAsync(user);
            var token = bearerTokenGenerator.GenerateToken(user, roles, claims);

            UserDto userDTO = new()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber
            };

            var loginResponseDto = new LoginResponseDto()
            {
                User = userDTO,
                Token = token,
            };

            return loginResponseDto;
        }

        public async Task<bool> AssignRole(string email, string role)
        {
            var user = identityApiDbContext.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                return false;
            }

            if (await roleManager.RoleExistsAsync(role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
            else
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                await userManager.AddToRoleAsync(user, role);
            }

            return true;
        }

        public async Task<bool> AssignClaims(string email, IEnumerable<ClaimDto> claimDtos)
        {
            var user = await userManager.FindByEmailAsync(email);
            var claims = claimDtos.Select(c => new Claim(c.Type, c.Value)).ToList();

            if (user == null)
            {
                return false;
            }

            var userClaims = await userManager.GetClaimsAsync(user);

            if (claims.Any(claim => userClaims.Any(c => c.Type == claim.Type && c.Value == claim.Value)))
            {
                return false;
            }

            var result = await userManager.AddClaimsAsync(user, claims);

            return true;
        }
    }
}
