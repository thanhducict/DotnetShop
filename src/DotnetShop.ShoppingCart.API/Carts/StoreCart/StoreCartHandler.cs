namespace DotnetShop.ShoppingCart.API.Carts.StoreCart
{
    public class StoreCartCommand(Cart cart) : ICommand<StoreCartResult>
    {
        public Cart Cart { get; } = cart;
    }

    public class StoreCartResult(bool isSuccess)
    {
        public bool IsSuccess { get; } = isSuccess;
    }

    public class StoreCartHandler : IRequestHandler<StoreCartCommand, StoreCartResult>
    {
        public Task<StoreCartResult> Handle(StoreCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
