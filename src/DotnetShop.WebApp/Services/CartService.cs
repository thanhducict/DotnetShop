using DotnetShop.WebApp.Models.Cart;

namespace DotnetShop.WebApp.Services
{
    public class CartService(HttpClient httpClient) : ICartService
    {
        public async Task<GetCartByUsernameResponse> GetCartByUsername(string username, CancellationToken cancellationToken)
        {
            try
            {
                var cart = await httpClient.GetFromJsonAsync<GetCartByUsernameResponse>($"carts/getcartbyusername/{username}", cancellationToken);
                return cart ?? new GetCartByUsernameResponse(new Cart());
            }
            catch
            {
                return new GetCartByUsernameResponse(new Cart());
            }
        }

        public async Task<HttpResponseMessage> StoreCart(Cart cart, CancellationToken cancellationToken)
        {
            return await httpClient.PostAsJsonAsync("carts", new StoreCartRequest(cart), cancellationToken)
                ?? throw new InvalidOperationException("Failed to store cart.");
        }

        // Pseudocode plan:
        // 1. HttpClient does not have a built-in DeleteFromJsonAsync method that sends a JSON body with DELETE.
        // 2. To send a JSON body with DELETE, use HttpRequestMessage with HttpMethod.Delete and set the Content to a StringContent with JSON.
        // 3. Serialize the object to JSON using JsonSerializer.
        // 4. Set the Content-Type header to "application/json".
        // 5. Send the request using httpClient.SendAsync and return the response.

        public async Task<HttpResponseMessage> RemoveFromCart(string username, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, "carts")
            {
                Content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(new DeleteCartRequest(username)),
                    System.Text.Encoding.UTF8,
                    "application/json")
            };

            var response = await httpClient.SendAsync(request, cancellationToken);
            return response ?? throw new InvalidOperationException("Failed to remove item from cart.");
        }

        public async Task<HttpResponseMessage> Checkout(CartCheckoutDto cartCheckoutDto, CancellationToken cancellationToken)
        {
            return await httpClient.PostAsJsonAsync("carts/checkout", new CheckoutCartRequest(cartCheckoutDto), cancellationToken)
                ?? throw new InvalidOperationException("Failed to checkout.");
        }
    }
}
