namespace DotnetShop.ShoppingCart.API.Models
{
    public class CartItem
    {
        public Guid ProductGuid { get; set; } = default!;
        public string ProductName { get; set; } = default!;
        public int Quantity { get; set; } = default!;
        public decimal Price { get; set; } = default!;
    }
}
