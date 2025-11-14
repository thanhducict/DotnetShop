using DotnetShop.Ordering.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DotnetShop.Ordering.Application.Orders.EventHandlers.Domain
{
    public class OrderEventPublisher(IServiceProvider provider) : IPublisher<IDomainEvent>
    {
        public async Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var domainEventType = domainEvent.GetType();
            var handlerType = typeof(ISubscriber<>).MakeGenericType(domainEventType);
            var subscribers = provider.GetServices(handlerType).Cast<object>().ToList();

            foreach (var subscriber in subscribers)
            {
                await (Task)subscriber.GetType()
                    .GetMethod("HandleAsync")
                    ?.Invoke(subscriber, new object[] { domainEvent, CancellationToken.None })!;
            }
        }
    }
}
