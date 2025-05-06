using DotnetShop.Common.Messaging.MessageBroker;
using DotnetShop.Ordering.Domain.Abstractions;
using System.Text.Json;

namespace DotnetShop.Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderCreatedEventHandler(MessageProducer messageProducer, IApplicationDbContext dbContext, ILogger<OrderCreatedEventHandler> logger) : ISubscriber<OrderCreatedEvent>
    {
        public async Task HandleAsync(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

            var orderCreatedIntegrationEvent = domainEvent.Order.ToOrderDto(dbContext);
            var message = JsonSerializer.Serialize(orderCreatedIntegrationEvent);

            await messageProducer.SendMessage("OrderCreated", message);
        }
    }
}
