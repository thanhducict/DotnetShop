using DotnetShop.Common.CQRS;

namespace DotnetShop.ShoppingCart.API.Carts.StoreCart
{
    public class StoreCartCommand : ICommand<StoreCartResult>
    {
    }

    public class StoreCartResult
    {
    }

    public class StoreCartHandler : ICommandHandler<StoreCartCommand, StoreCartResult>
    {
        public Task<StoreCartResult> Handle(StoreCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
