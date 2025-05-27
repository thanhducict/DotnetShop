using DotnetShop.WebApp.Models.Cart;

namespace DotnetShop.WebApp.Services
{
    public class CartService(HttpClient httpClient) : ICartService
    {
        public async Task<GetCartByUsernameResponse> GetCartByUsername(string username, CancellationToken cancellationToken)
        {
            return await httpClient.GetFromJsonAsync<GetCartByUsernameResponse>($"carts/getcartbyusername/{username}", cancellationToken)
                ?? new GetCartByUsernameResponse(new Cart());
        }
    }
}
