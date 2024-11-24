namespace DotnetShop.ShoppingCart.API.Carts.DeleteCart
{
    public class DeleteCartCommand(string username) : ICommand<DeleteCartResult>
    {
        public string Username { get; } = username;
    }

    public class DeleteCartResult(bool isSuccess)
    {
        public bool IsSuccess { get; } = isSuccess;
    }

    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
    {
        public Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
