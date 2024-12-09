namespace DotnetShop.ShoppingCart.API.Models
{
    public class Cart(string username)
    {
        public string Username { get; } = username;
        public List<CartItem> Items { get; set; } = [];
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}
