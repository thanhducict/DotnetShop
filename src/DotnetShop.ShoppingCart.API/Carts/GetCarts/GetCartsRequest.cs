namespace DotnetShop.ShoppingCart.API.Carts.GetCarts
{
    public class GetCartsRequest()
    {
        public int PageNumber { get; } = 1;
        public int PageSize { get; } = 10;
    }
}
