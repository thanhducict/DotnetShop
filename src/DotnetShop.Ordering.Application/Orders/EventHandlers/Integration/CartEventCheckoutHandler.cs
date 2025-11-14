using DotnetShop.Common.Messaging.Events;
using DotnetShop.Common.Messaging.MessageBroker;
using DotnetShop.Ordering.Application.Orders.Commands.CreateOrder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using System.Text.Json;

namespace DotnetShop.Ordering.Application.Orders.EventHandlers.Integration
{
    public class CartCheckoutEventHandler(IServiceProvider container, MessageConsumer messageConsumer, ILogger<CartCheckoutEventHandler> logger)
        : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            messageConsumer.AddListener("Checkout", "CartCheckout", async (_, args) =>
            {
                byte[] body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                logger.LogInformation("Integration Event handled: {IntegrationEvent}", message);
                using var scope = container.CreateScope();
                var dispatcher = scope.ServiceProvider.GetRequiredService<IRequestDispatcher>();

                var command = MapToCreateOrderCommand(message);
                if (command != null)
                {
                    await dispatcher.DispatchAsync(command);
                }
            });

            return Task.CompletedTask;
        }

        private CreateOrderCommand? MapToCreateOrderCommand(string message)
        {
            var model = JsonSerializer.Deserialize<CartCheckoutEvent>(message);

            if (model != null)
            {
                var customerDto = new CustomerDto(model.Customer.CustomerGuid, model.Customer.Username, model.Customer.Email);
                var shippingAddressDto = new AddressDto(model.ShippingAddress.FirstName, model.ShippingAddress.LastName,
                    model.ShippingAddress.EmailAddress, model.ShippingAddress.AddressLine, model.ShippingAddress.Country,
                    model.ShippingAddress.State, model.ShippingAddress.ZipCode);
                var billingAddressDto = new AddressDto(model.BillingAddress.FirstName, model.BillingAddress.LastName,
                    model.BillingAddress.EmailAddress, model.BillingAddress.AddressLine, model.BillingAddress.Country,
                    model.BillingAddress.State, model.BillingAddress.ZipCode);
                var paymentDto = new PaymentDto(model.Payment.CardName, model.Payment.CardNumber, model.Payment.Expiration,
                    model.Payment.CVV, model.Payment.PaymentMethod);

                var lineItems = new List<OrderItemDto>();
                foreach (var item in model.CartItems)
                {
                    lineItems.Add(new OrderItemDto(Guid.Empty, item.ProductGuid, item.ProductName, item.Quantity, item.Price));
                }

                var orderDto = new OrderDto(
                    Id: Guid.Empty,
                    OrderName: string.Empty,
                    Customer: customerDto,
                    ShippingAddress: shippingAddressDto,
                    BillingAddress: billingAddressDto,
                    Payment: paymentDto,
                    Status: Ordering.Domain.Enums.OrderStatus.Pending,
                    OrderItems: lineItems
                );

                return new CreateOrderCommand(orderDto);
            }
            else
            {
                return null;
            }
        }
    }
}
