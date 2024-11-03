using DotnetShop.Common.CQRS;

namespace DotnetShop.ShoppingCart.API.Carts.CheckoutCart
{
    public class CheckoutCartCommand : ICommand<CheckoutCartResult>
    {

    }

    public class CheckoutCartResult
    {

    }

    public class CheckoutCartCommandHandler : ICommandHandler<CheckoutCartCommand, CheckoutCartResult>
    {
        public Task<CheckoutCartResult> Handle(CheckoutCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
