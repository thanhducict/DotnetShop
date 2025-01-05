using DotnetShop.Discount.Grpc;
using DotnetShop.ShoppingCart.API.Repositories;
using FluentValidation;

namespace DotnetShop.ShoppingCart.API.Carts.StoreCart
{
    public class StoreCartCommand(Cart cart) : ICommand<StoreCartResult>
    {
        public Cart Cart { get; } = cart;
    }

    public class StoreCartResult(string username)
    {
        public string Username { get; } = username;
    }

    public class StoreCartCommandValidator : AbstractValidator<StoreCartCommand>
    {
        public StoreCartCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
            RuleFor(x => x.Cart.Username).NotEmpty().WithMessage("UserName is required");
        }
    }

    public class StoreCartHandler(ICartRepository cartRepository, DiscountProtoService.DiscountProtoServiceClient discountClient) : IRequestHandler<StoreCartCommand, StoreCartResult>
    {
        public async Task<StoreCartResult> Handle(StoreCartCommand command, CancellationToken cancellationToken)
        {
            foreach (var item in command.Cart.Items)
            {
                var coupon = await discountClient.GetDiscountAsync(new GetDiscountRequest { ProductGuid = item.ProductGuid.ToString() }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }

            var cart = command.Cart;

            var result = await cartRepository.StoreCart(cart, cancellationToken);

            return new StoreCartResult(result.Username);
        }
    }
}
