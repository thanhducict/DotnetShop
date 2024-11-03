namespace DotnetShop.ShoppingCart.API.Carts.GetCart
{
    public class GetCartResponse(IEnumerable<Cart> carts)
    {
        public IEnumerable<Cart> Carts { get; } = carts;
    }
}
