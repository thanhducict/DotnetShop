namespace DotnetShop.ShoppingCart.API.Repositories
{
    public interface ICartRepository
    {
        Task<IEnumerable<Cart>> GetCarts(CancellationToken cancellationToken = default);
        Task<Cart> GetCartByUsername(string username, CancellationToken cancellationToken = default);
        Task<Cart> StoreCart(Cart cart, CancellationToken cancellationToken = default);
        Task<bool> DeleteCart(string username, CancellationToken cancellationToken = default);
    }
}
