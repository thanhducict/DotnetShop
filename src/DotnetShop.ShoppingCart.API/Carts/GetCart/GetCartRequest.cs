namespace DotnetShop.ShoppingCart.API.Carts.GetCart
{
    public class GetCartRequest(string username)
    {
        public string Username { get; } = username;
    }
}
