namespace DotnetShop.Identity.API.Dtos
{
    public class RegistrationRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Role { get; set; }
        public List<ClaimDto>? Claims { get; set; } = new List<ClaimDto>();
    }
}
