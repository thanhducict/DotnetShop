using DotnetShop.Ordering.Domain.Enums;

namespace DotnetShop.Ordering.Application.Dtos
{
    public record OrderDto(Guid Id, string OrderName, CustomerDto Customer, List<OrderItemDto> OrderItems, AddressDto ShippingAddress,
        AddressDto BillingAddress, PaymentDto Payment, OrderStatus Status);
}
