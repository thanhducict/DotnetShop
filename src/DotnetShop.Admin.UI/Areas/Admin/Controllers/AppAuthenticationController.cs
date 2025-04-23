using DotnetShop.Admin.UI.Areas.Admin.Dtos;
using DotnetShop.Admin.UI.Areas.Admin.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace DotnetShop.Admin.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppAuthenticationController(IAppAuthenticationService appAuthenticationService) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginDto());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto, string? returnUrl = null)
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

                return RedirectToAction("Index", "Catalog", new { area = "Admin" });
            }

            return View(loginDto);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string? returnUrl)
        {
            await HttpContext.SignOutAsync(Constants.MyBearerScheme);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Catalog", new { area = "Admin" });
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
