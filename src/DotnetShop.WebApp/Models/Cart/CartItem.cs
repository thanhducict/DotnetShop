namespace DotnetShop.WebApp.Models.Cart
{
    public class CartItem
    {
        public Guid ProductGuid { get; set; } = Guid.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
