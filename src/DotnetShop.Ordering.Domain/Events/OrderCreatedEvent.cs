namespace DotnetShop.Ordering.Domain.Events
{
    public record OrderCreatedEvent(Order Order) : IDomainEvent;
}
