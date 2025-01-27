namespace DotnetShop.Ordering.Domain.Events
{
    public record OrderUpdatedEvent(Order order) : IDomainEvent;
}
