using DotnetShop.Common.Messaging.MessageBroker;
using System.Text.Json;

namespace DotnetShop.Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderUpdatedEventHandler(MessageProducer messageProducer, IApplicationDbContext dbContext, ILogger<OrderUpdatedEventHandler> logger)
        : INotificationHandler<OrderUpdatedEvent>
    {
        public async Task Handle(OrderUpdatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

            var orderCreatedIntegrationEvent = domainEvent.Order.ToOrderDto(dbContext);
            var message = JsonSerializer.Serialize(orderCreatedIntegrationEvent);

            await messageProducer.SendMessage("OrderUpdated", message);
            // print the result because there is no consumer yet.
            //await Task.Run(() => logger.LogInformation("Order updated: \n{message}", message), cancellationToken);
        }
    }
}
