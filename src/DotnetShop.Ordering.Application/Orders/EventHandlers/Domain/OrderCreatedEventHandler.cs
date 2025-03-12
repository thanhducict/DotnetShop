using DotnetShop.Common.Messaging.MessageBroker;
using System.Text.Json;

namespace DotnetShop.Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler(MessageProducer messageProducer, IApplicationDbContext dbContext, ILogger<OrderCreatedEventHandler> logger) : INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

            var orderCreatedIntegrationEvent = domainEvent.Order.ToOrderDto(dbContext);
            var message = JsonSerializer.Serialize(orderCreatedIntegrationEvent);

            await messageProducer.SendMessage("OrderCreated", message);
            // print the result because there is no consumer yet.
            //await Task.Run(() => logger.LogInformation("Order created: \n{message}", message), cancellationToken);
        }
    }
}
