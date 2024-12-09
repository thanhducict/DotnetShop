using DotnetShop.Common.Exceptions;

namespace DotnetShop.ShoppingCart.API.Exceptions
{
    public class CartNotFoundException : NotFoundException
    {
        public CartNotFoundException(string username) : base("Cart", username)
        {
        }
    }
}
