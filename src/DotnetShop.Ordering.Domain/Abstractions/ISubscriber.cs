namespace DotnetShop.Ordering.Domain.Abstractions
{
    public interface ISubscriber<TEvent> where TEvent : IDomainEvent
    {
        Task HandleAsync(TEvent @event, CancellationToken cancellationToken);
    }
}
