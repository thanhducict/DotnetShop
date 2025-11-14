using DotnetShop.WebApp.Models.Cart;

namespace DotnetShop.WebApp.Services
{
    public interface ICartService
    {
        Task<GetCartByUsernameResponse> GetCartByUsername(string username, CancellationToken cancellationToken);
        Task<HttpResponseMessage> StoreCart(Cart cart, CancellationToken cancellationToken);
        Task<HttpResponseMessage> RemoveFromCart(string username, CancellationToken cancellationToken);
        Task<HttpResponseMessage> Checkout(CartCheckoutDto cartCheckoutDto, CancellationToken cancellationToken);
    }
}
