namespace DotnetShop.Ordering.Application.Extensions
{
    public static class OrderExtensions
    {
        public static IEnumerable<OrderDto> ToOrderDtoList(this IEnumerable<Order> orders, IApplicationDbContext dbContext)
        {
            var customers = dbContext.Customers.ToList();
            var products = dbContext.Products.ToList();

            return orders.Select(order => new OrderDto(
                Id: order.Id.Value,
                OrderName: order.OrderName.Value,
                Customer: customers.Where(c => c.Id.Value == order.CustomerId.Value).Select(c => new CustomerDto(
                    c.Id.Value,
                    c.Username,
                    c.Email
                )).FirstOrDefault()!,
                OrderItems: order.OrderItems.Select(oi => new OrderItemDto(oi.OrderId.Value,
                    oi.ProductId.Value,
                    products.Where(p => p.Id.Value == oi.ProductId.Value).Select(p => p.Name).FirstOrDefault()!,
                    oi.Quantity,
                    oi.Price)).ToList(),
                ShippingAddress: new AddressDto(order.ShippingAddress.FirstName, order.ShippingAddress.LastName, order.ShippingAddress.EmailAddress!, order.ShippingAddress.AddressLine, order.ShippingAddress.Country, order.ShippingAddress.State, order.ShippingAddress.ZipCode),
                BillingAddress: new AddressDto(order.BillingAddress.FirstName, order.BillingAddress.LastName, order.BillingAddress.EmailAddress!, order.BillingAddress.AddressLine, order.BillingAddress.Country, order.BillingAddress.State, order.BillingAddress.ZipCode),
                Payment: new PaymentDto(order.Payment.CardName!, order.Payment.CardNumber, order.Payment.Expiration, order.Payment.CVV, order.Payment.PaymentMethod),
                Status: order.Status
            ));
        }

        public static OrderDto ToOrderDto(this Order order, IApplicationDbContext dbContext)
        {
            var customers = dbContext.Customers.ToList();
            var products = dbContext.Products.ToList();

            return new OrderDto(
                Id: order.Id.Value,
                Customer: customers.Where(c => c.Id.Value == order.CustomerId.Value).Select(c => new CustomerDto(
                    c.Id.Value,
                    c.Username,
                    c.Email
                )).FirstOrDefault(),
                OrderName: order.OrderName.Value,
                ShippingAddress: new AddressDto(order.ShippingAddress.FirstName, order.ShippingAddress.LastName, order.ShippingAddress.EmailAddress!, order.ShippingAddress.AddressLine, order.ShippingAddress.Country, order.ShippingAddress.State, order.ShippingAddress.ZipCode),
                BillingAddress: new AddressDto(order.BillingAddress.FirstName, order.BillingAddress.LastName, order.BillingAddress.EmailAddress!, order.BillingAddress.AddressLine, order.BillingAddress.Country, order.BillingAddress.State, order.BillingAddress.ZipCode),
                Payment: new PaymentDto(order.Payment.CardName!, order.Payment.CardNumber, order.Payment.Expiration, order.Payment.CVV, order.Payment.PaymentMethod),
                Status: order.Status,
                OrderItems: order.OrderItems.Select(oi => new OrderItemDto(
                    oi.OrderId.Value,
                    oi.ProductId.Value,
                    products.Where(p => p.Id.Value == oi.ProductId.Value).Select(p => p.Name).FirstOrDefault()!,
                    oi.Quantity,
                    oi.Price)).ToList()
            );
        }
    }
}
