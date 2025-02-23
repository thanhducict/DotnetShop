using DotnetShop.ShoppingCart.API.Dtos;

namespace DotnetShop.ShoppingCart.API.Carts.CheckoutCart
{
    public class CheckoutCartCommand(CartCheckoutDto cartCheckoutDto) : ICommand<CheckoutCartResult>
    {
        public CartCheckoutDto CartCheckoutDto { get; set; } = cartCheckoutDto;
    }

    public class CheckoutCartResult(bool isSuccess)
    {
        public bool IsSuccess { get; set; } = isSuccess;
    }

    public class CheckoutCartCommandHandler : IRequestHandler<CheckoutCartCommand, CheckoutCartResult>
    {
        public Task<CheckoutCartResult> Handle(CheckoutCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
