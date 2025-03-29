namespace DotnetShop.Ordering.Application.Dtos
{
    public record OrderItemDto(Guid OrderId, Guid ProductId, string ProductName, int Quantity, decimal Price);
}
