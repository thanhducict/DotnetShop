namespace DotnetShop.Ordering.Domain.Abstractions
{
    public interface IPublisher<TEvent> where TEvent : IDomainEvent
    {
        Task PublishAsync(TEvent @event, CancellationToken cancellationToken);
    }
}
