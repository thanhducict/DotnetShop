namespace DotnetShop.ShoppingCart.API.Carts.StoreCart
{
    public class StoreCartResponse(string username)
    {
        public string Username { get; } = username;
    }
}
