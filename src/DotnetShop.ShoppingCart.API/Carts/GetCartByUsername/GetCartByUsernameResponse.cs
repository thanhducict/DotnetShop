namespace DotnetShop.ShoppingCart.API.Carts.GetCartByUsername
{
    public class GetCartByUsernameResponse(Cart cart)
    {
        public Cart Cart { get; } = cart;
    }
}
