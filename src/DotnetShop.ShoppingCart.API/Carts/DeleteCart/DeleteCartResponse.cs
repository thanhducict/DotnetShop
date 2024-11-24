namespace DotnetShop.ShoppingCart.API.Carts.DeleteCart
{
    public class DeleteCartResponse(bool isSuccess)
    {
        public bool IsSuccess { get; } = isSuccess;
    }
}
