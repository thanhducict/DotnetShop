using DotnetShop.WebApp.Models.Identity;
using System.Text.Json;

namespace DotnetShop.WebApp.Services
{
    public class IdentityService(HttpClient httpClient) : IIdentityService
    {
        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<LoginResponseDto> LoginAsync(string userName, string password)
        {
            var request = new LoginRequestDto
            {
                UserName = userName,
                Password = password
            };

            var response = await httpClient.PostAsJsonAsync("appauthentication/login", request);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResponseDto>(content, JsonSerializerOptions);

            if (result != null)
            {
                return result;
            }
            else
            {
                return new LoginResponseDto();
            }
        }
    }
}
