namespace DotnetShop.ShoppingCart.API.Carts.DeleteCart
{
    public class DeleteCartCommand : IRequest<DeleteCartResult>
    {

    }

    public class DeleteCartResult
    {

    }

    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
    {
        public Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
