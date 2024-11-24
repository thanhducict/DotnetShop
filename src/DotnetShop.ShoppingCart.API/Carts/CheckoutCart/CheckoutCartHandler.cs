namespace DotnetShop.ShoppingCart.API.Carts.CheckoutCart
{
    public class CheckoutCartCommand : ICommand<CheckoutCartResult>
    {

    }

    public class CheckoutCartResult
    {

    }

    public class CheckoutCartCommandHandler : IRequestHandler<CheckoutCartCommand, CheckoutCartResult>
    {
        public Task<CheckoutCartResult> Handle(CheckoutCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
