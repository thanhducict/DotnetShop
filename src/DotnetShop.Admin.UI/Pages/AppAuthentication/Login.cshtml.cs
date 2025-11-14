using DotnetShop.Admin.UI.Dtos;
using DotnetShop.Admin.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DotnetShop.Admin.UI.Pages.AppAuthentication
{
    public class LoginModel(IAppAuthenticationService appAuthenticationService) : PageModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(LoginDto loginDto, string? returnUrl = null)
        {
            var response = await appAuthenticationService.LoginAsync(new LoginRequestDto
            {
                UserName = loginDto.UserName,
                Password = loginDto.Password,
            });

            if (response.User != null && !string.IsNullOrEmpty(response.Token))
            {
                var handler = new JwtSecurityTokenHandler();
                var token = handler.ReadJwtToken(response.Token);
                var identity = new ClaimsIdentity(token.Claims, Constants.MyBearerScheme);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = loginDto.RememberMe,
                };

                await HttpContext.SignInAsync(Constants.MyBearerScheme, claimsPrincipal, authProperties);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToPage("/Catalog/List");
            }

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> OnPostLogout(string? returnUrl)
        {
            await HttpContext.SignOutAsync(Constants.MyBearerScheme);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToPage("/Catalog/List");
        }

        public void OnGetRegister()
        {
        }
    }
}
