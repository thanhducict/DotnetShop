namespace DotnetShop.WebApp.Models.Identity
{
    public class LoginResponseDto
    {
        public UserDto User { get; set; } = default!;
        public string Token { get; set; } = string.Empty;
        public string Message { get; set; }
    }
}
