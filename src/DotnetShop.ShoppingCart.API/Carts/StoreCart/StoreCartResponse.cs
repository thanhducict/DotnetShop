namespace DotnetShop.ShoppingCart.API.Carts.StoreCart
{
    public class StoreCartResponse(bool isSuccess)
    {
        public bool IsSuccess { get; } = isSuccess;
    }
}
