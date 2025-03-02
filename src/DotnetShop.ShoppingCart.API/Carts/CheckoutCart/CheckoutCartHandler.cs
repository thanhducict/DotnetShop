using DotnetShop.Common.Messaging.Events;
using DotnetShop.ShoppingCart.API.Dtos;
using DotnetShop.ShoppingCart.API.Producers;
using DotnetShop.ShoppingCart.API.Repositories;
using System.Text.Json;

namespace DotnetShop.ShoppingCart.API.Carts.CheckoutCart
{
    public class CheckoutCartCommand(CartCheckoutDto cartCheckoutDto) : ICommand<CheckoutCartResult>
    {
        public CartCheckoutDto CartCheckoutDto { get; set; } = cartCheckoutDto;
    }

    public class CheckoutCartResult(bool isSuccess)
    {
        public bool IsSuccess { get; set; } = isSuccess;
    }

    public class CheckoutCartCommandHandler(ICartRepository cartRepository, CartCheckoutProducer cartCheckoutPublisher)
        : IRequestHandler<CheckoutCartCommand, CheckoutCartResult>
    {
        public async Task<CheckoutCartResult> Handle(CheckoutCartCommand command, CancellationToken cancellationToken)
        {
            var cart = await cartRepository.GetCartByUsername(command.CartCheckoutDto.UserName, cancellationToken);
            if (cart == null)
            {
                return new CheckoutCartResult(false);
            }

            var cartCheckoutEvent = new CartCheckoutEvent
            {
                UserName = command.CartCheckoutDto.UserName,
                CustomerId = command.CartCheckoutDto.CustomerId,
                TotalPrice = command.CartCheckoutDto.TotalPrice,

                FirstName = command.CartCheckoutDto.FirstName,
                LastName = command.CartCheckoutDto.LastName,
                EmailAddress = command.CartCheckoutDto.EmailAddress,
                AddressLine = command.CartCheckoutDto.AddressLine,
                Country = command.CartCheckoutDto.Country,
                State = command.CartCheckoutDto.State,
                ZipCode = command.CartCheckoutDto.ZipCode,

                CardName = command.CartCheckoutDto.CardName,
                CardNumber = command.CartCheckoutDto.CardNumber,
                Expiration = command.CartCheckoutDto.Expiration,
                CVV = command.CartCheckoutDto.CVV,
                PaymentMethod = command.CartCheckoutDto.PaymentMethod,
            };
            cartCheckoutEvent.TotalPrice = cart.TotalPrice;

            var message = JsonSerializer.Serialize(cartCheckoutEvent);

            await cartCheckoutPublisher.SendMessage("Checkout", message);

            await cartRepository.DeleteCart(command.CartCheckoutDto.UserName, cancellationToken);

            return new CheckoutCartResult(true);
        }
    }
}
