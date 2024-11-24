using FluentValidation;

namespace DotnetShop.ShoppingCart.API.Carts.CheckoutCart
{
    public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutCartCommand>
    {
        public CheckoutBasketCommandValidator()
        {
            //RuleFor(x => x.BasketCheckoutDto).NotNull().WithMessage("BasketCheckoutDto can't be null");
            //RuleFor(x => x.BasketCheckoutDto.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
}
