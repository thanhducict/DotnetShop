using DotnetShop.Identity.API.Dtos;
using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity;

namespace DotnetShop.Identity.API.Services
{
    public class AuthenticationService(
        IdentityApiDbContext db,
        IJwtTokenGenerator jwtTokenGenerator,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager) : IAuthenticationService
    {
        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            //ApplicationUser user = new()
            //{
            //    UserName = registrationRequestDto.Email,
            //    Email = registrationRequestDto.Email,
            //    NormalizedEmail = registrationRequestDto.Email.ToUpper(),
            //    FirstName = registrationRequestDto.Firstname,
            //    LastName = registrationRequestDto.Lastname,
            //    PhoneNumber = registrationRequestDto.PhoneNumber
            //};

            //try
            //{
            //    var result = await userManager.CreateAsync(user, registrationRequestDto.Password);
            //    if (result.Succeeded)
            //    {
            //        var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

            //        UserDto userDto = new()
            //        {
            //            Email = userToReturn.Email,
            //            ID = userToReturn.Id,
            //            Name = userToReturn.Name,
            //            PhoneNumber = userToReturn.PhoneNumber
            //        };

            //        return "";

            //    }
            //    else
            //    {
            //        return result.Errors.FirstOrDefault().Description;
            //    }

            //}
            //catch (Exception ex)
            //{

            //}
            return "Error Encountered";
        }
         
        public async Task<bool> AssignRole(string email, string roleName)
        {
            //var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            //if (user != null)
            //{
            //    if (!roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
            //    {
            //        //create role if it does not exist
            //        roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
            //    }
            //    await userManager.AddToRoleAsync(user, roleName);
            //    return true;
            //}
            return false;

        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            //var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            //bool isValid = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            //if (user == null || isValid == false)
            //{
            //    return new LoginResponseDto() { User = null, Token = "" };
            //}

            ////if user was found , Generate JWT Token
            //var roles = await userManager.GetRolesAsync(user);
            //var token = jwtTokenGenerator.GenerateToken(user, roles);

            //UserDto userDTO = new()
            //{
            //    Email = user.Email,
            //    ID = user.Id,
            //    Name = user.Name,
            //    PhoneNumber = user.PhoneNumber
            //};

            //LoginResponseDto loginResponseDto = new LoginResponseDto()
            //{
            //    User = userDTO,
            //    Token = token
            //};

            return new LoginResponseDto();
        }

    }
}
