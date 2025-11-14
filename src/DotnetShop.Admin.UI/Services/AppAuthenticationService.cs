using DotnetShop.Admin.Core.HttpClient;
using DotnetShop.Admin.UI.Dtos;

namespace DotnetShop.Admin.UI.Services
{
    public class AppAuthenticationService(IHttpClientFactoryBase httpClientFactoryBase, IConfiguration configuration)
        : IAppAuthenticationService
    {
        private readonly string IdentityBaseUri = configuration["ServiceUri:Identity"]!;

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await httpClientFactoryBase.PostAsync<LoginResponseDto>
                (Constants.AuthenticationClient, $"{IdentityBaseUri}/appauthentication/login", loginRequestDto);
        }
    }
}
