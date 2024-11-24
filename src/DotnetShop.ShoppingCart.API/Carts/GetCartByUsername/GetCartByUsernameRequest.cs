namespace DotnetShop.ShoppingCart.API.Carts.GetCartByUsername
{
    public class GetCartByUsernameRequest(string username)
    {
        public string Username { get; } = username;
    }
}
