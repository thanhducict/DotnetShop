namespace DotnetShop.WebApp.Models.Cart
{
    public class Cart
    {
        public string Username { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = [];
        public decimal TotalPrice { get; set; }
    }

    public record GetCartByUsernameResponse(Cart Cart);
    public record StoreCartRequest(Cart Cart);
}
