using DotnetShop.Common.CQRS;

namespace DotnetShop.ShoppingCart.API.Carts.DeleteCart
{
    public class DeleteCartCommand : ICommand<DeleteCartResult>
    {

    }

    public class DeleteCartResult
    {

    }

    public class DeleteCartHandler : ICommandHandler<DeleteCartCommand, DeleteCartResult>
    {
        public Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
