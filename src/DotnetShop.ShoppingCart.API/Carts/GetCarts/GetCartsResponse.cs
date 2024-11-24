namespace DotnetShop.ShoppingCart.API.Carts.GetCarts
{
    public class GetCartsResponse(IEnumerable<Cart> carts)
    {
        public IEnumerable<Cart> Carts { get; } = carts;
    }
}
