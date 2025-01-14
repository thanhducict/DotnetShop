using DotnetShop.ShoppingCart.API.Repositories;
using FluentValidation;

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

    public class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommand>
    {
        public DeleteCartCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("UserName is required");
        }
    }

    public class DeleteCartHandler(ICartRepository cartRepository) : IRequestHandler<DeleteCartCommand, DeleteCartResult>
    {
        public async Task<DeleteCartResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var result = await cartRepository.DeleteCart(request.Username, cancellationToken);

            return new DeleteCartResult(result);
        }
    }
}
