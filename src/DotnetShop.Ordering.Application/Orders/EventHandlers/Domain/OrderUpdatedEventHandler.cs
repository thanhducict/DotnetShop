using DotnetShop.Common.Messaging.MessageBroker;
using DotnetShop.Ordering.Domain.Abstractions;
using System.Text.Json;

namespace DotnetShop.Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderUpdatedEventHandler(MessageProducer messageProducer, IApplicationDbContext dbContext, ILogger<OrderUpdatedEventHandler> logger)
        : ISubscriber<OrderUpdatedEvent>
    {
        public async Task HandleAsync(OrderUpdatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

            var orderCreatedIntegrationEvent = domainEvent.Order.ToOrderDto(dbContext);
            var message = JsonSerializer.Serialize(orderCreatedIntegrationEvent);

            await messageProducer.SendMessage("OrderUpdated", message);
        }
    }
}
