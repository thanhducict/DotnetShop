using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace DotnetShop.ShoppingCart.API.Repositories
{
    public class CachedCartRepository(ICartRepository cartRepository, IDistributedCache distributedCache) : ICartRepository
    {
        public async Task<IEnumerable<Cart>> GetCarts(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var cachedCarts = await distributedCache.GetStringAsync("allCarts", cancellationToken);
            if (!string.IsNullOrEmpty(cachedCarts))
            {
                return JsonSerializer.Deserialize<IEnumerable<Cart>>(cachedCarts)!;
            }

            var carts = await cartRepository.GetCarts(pageNumber, pageSize, cancellationToken);
            await distributedCache.SetStringAsync("allCarts", JsonSerializer.Serialize(carts), cancellationToken);

            return carts;
        }

        public async Task<Cart> GetCartByUsername(string userName, CancellationToken cancellationToken = default)
        {
            var cachedCart = await distributedCache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cachedCart))
            {
                return JsonSerializer.Deserialize<Cart>(cachedCart)!;
            }

            var cart = await cartRepository.GetCartByUsername(userName, cancellationToken);
            await distributedCache.SetStringAsync(userName, JsonSerializer.Serialize(cart), cancellationToken);

            return cart;
        }

        public async Task<Cart> StoreCart(Cart cart, CancellationToken cancellationToken = default)
        {
            await cartRepository.StoreCart(cart, cancellationToken);

            await distributedCache.SetStringAsync(cart.Username, JsonSerializer.Serialize(cart), cancellationToken);

            return cart;
        }

        public async Task<bool> DeleteCart(string userName, CancellationToken cancellationToken = default)
        {
            await cartRepository.DeleteCart(userName, cancellationToken);

            await distributedCache.RemoveAsync(userName, cancellationToken);

            return true;
        }
    }
}
