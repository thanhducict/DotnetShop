namespace DotnetShop.Ordering.Domain.Events
{
    public record OrderCreatedEvent(Order order) : IDomainEvent;
}
