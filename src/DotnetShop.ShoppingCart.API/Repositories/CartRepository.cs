using DotnetShop.ShoppingCart.API.Exceptions;
using Marten;

namespace DotnetShop.ShoppingCart.API.Repositories
{
    public class CartRepository(IDocumentSession session) : ICartRepository
    {
        public async Task<IEnumerable<Cart>> GetCarts(CancellationToken cancellationToken = default)
        {
            var carts = await session.Query<Cart>().ToListAsync(token: cancellationToken);

            return carts;
        }

        public async Task<Cart> GetCartByUsername(string username, CancellationToken cancellationToken = default)
        {
            var cart = await session.LoadAsync<Cart>(username, cancellationToken);

            return cart is null ? throw new CartNotFoundException(username) : cart;
        }

        public async Task<Cart> StoreCart(Cart cart, CancellationToken cancellationToken = default)
        {
            session.Store(cart);
            await session.SaveChangesAsync(cancellationToken);

            return cart;
        }

        public async Task<bool> DeleteCart(string username, CancellationToken cancellationToken = default)
        {
            session.Delete<Cart>(username);
            await session.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
