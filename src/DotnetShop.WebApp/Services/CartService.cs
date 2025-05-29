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

        public async Task<HttpResponseMessage> StoreCart(Cart cart, CancellationToken cancellationToken)
        {
            return await httpClient.PostAsJsonAsync("carts", new StoreCartRequest(cart), cancellationToken)
                ?? throw new InvalidOperationException("Failed to store cart.");
        }
    }
}
