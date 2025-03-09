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
            var cart = await cartRepository.GetCartByUsername(command.CartCheckoutDto.Customer.Username, cancellationToken);
            if (cart == null)
            {
                return new CheckoutCartResult(false);
            }

            var cartItems = new List<Common.Messaging.Events.CartItem>();
            foreach (var item in cart.Items)
            {
                cartItems.Add(new Common.Messaging.Events.CartItem
                {
                    ProductGuid = item.ProductGuid,
                    ProductName = item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                });
            }

            var cartCheckoutEvent = new CartCheckoutEvent
            {
                Customer = new Common.Messaging.Events.Customer
                {
                    CustomerGuid = command.CartCheckoutDto.Customer.CustomerGuid,
                    Username = command.CartCheckoutDto.Customer.Username,
                    Email = command.CartCheckoutDto.Customer.Email
                },
                CartItems = cartItems,
                ShippingAddress = new Common.Messaging.Events.Address
                {
                    FirstName = command.CartCheckoutDto.ShippingAddress.FirstName,
                    LastName = command.CartCheckoutDto.ShippingAddress.LastName,
                    EmailAddress = command.CartCheckoutDto.ShippingAddress.EmailAddress,
                    AddressLine = command.CartCheckoutDto.ShippingAddress.AddressLine,
                    Country = command.CartCheckoutDto.ShippingAddress.Country,
                    State = command.CartCheckoutDto.ShippingAddress.State,
                    ZipCode = command.CartCheckoutDto.ShippingAddress.ZipCode
                },
                BillingAddress = new Common.Messaging.Events.Address
                {
                    FirstName = command.CartCheckoutDto.BillingAddress.FirstName,
                    LastName = command.CartCheckoutDto.BillingAddress.LastName,
                    EmailAddress = command.CartCheckoutDto.BillingAddress.EmailAddress,
                    AddressLine = command.CartCheckoutDto.BillingAddress.AddressLine,
                    Country = command.CartCheckoutDto.BillingAddress.Country,
                    State = command.CartCheckoutDto.BillingAddress.State,
                    ZipCode = command.CartCheckoutDto.BillingAddress.ZipCode
                },
                Payment = new Common.Messaging.Events.Payment
                {
                    CardName = command.CartCheckoutDto.Payment.CardName,
                    CardNumber = command.CartCheckoutDto.Payment.CardNumber,
                    Expiration = command.CartCheckoutDto.Payment.Expiration,
                    CVV = command.CartCheckoutDto.Payment.CVV,
                    PaymentMethod = command.CartCheckoutDto.Payment.PaymentMethod,
                },
                TotalPrice = command.CartCheckoutDto.TotalPrice,
            };

            cartCheckoutEvent.TotalPrice = cart.TotalPrice;

            var message = JsonSerializer.Serialize(cartCheckoutEvent);

            await cartCheckoutPublisher.SendMessage("Checkout", message);

            await cartRepository.DeleteCart(command.CartCheckoutDto.Customer.Username, cancellationToken);

            return new CheckoutCartResult(true);
        }
    }
}
