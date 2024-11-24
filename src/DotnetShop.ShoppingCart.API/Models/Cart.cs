namespace DotnetShop.ShoppingCart.API.Models
{
    public class Cart(string userName)
    {
        public string UserName { get; } = userName;
        public List<CartItem> Items { get; set; } = [];
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    }
}
