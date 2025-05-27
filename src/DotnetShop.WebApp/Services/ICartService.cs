using DotnetShop.WebApp.Models.Cart;

namespace DotnetShop.WebApp.Services
{
    public interface ICartService
    {
        Task<GetCartByUsernameResponse> GetCartByUsername(string username, CancellationToken cancellationToken);
    }
}
