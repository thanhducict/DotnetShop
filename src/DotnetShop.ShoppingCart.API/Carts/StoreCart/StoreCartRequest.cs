namespace DotnetShop.ShoppingCart.API.Carts.StoreCart
{
    public class StoreCartRequest(Cart cart)
    {
        public Cart Cart { get; } = cart;
    }
}
