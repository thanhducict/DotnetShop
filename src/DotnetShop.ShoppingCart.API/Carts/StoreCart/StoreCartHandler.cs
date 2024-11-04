namespace DotnetShop.ShoppingCart.API.Carts.StoreCart
{
    public class StoreCartCommand : IRequest<StoreCartResult>
    {
    }

    public class StoreCartResult
    {
    }

    public class StoreCartHandler : IRequestHandler<StoreCartCommand, StoreCartResult>
    {
        public Task<StoreCartResult> Handle(StoreCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
