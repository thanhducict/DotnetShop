namespace DotnetShop.Ordering.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler(IApplicationDbContext dbContext)
        : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            CreateCustomerIfNotExistsAsync(command.Order, cancellationToken);
            CreateProductsIfNotExistsAsync(command.Order, cancellationToken);

            var order = CreateNewOrder(command.Order);
            dbContext.Orders.Add(order);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new CreateOrderResult(order.Id.Value);
        }

        private async void CreateCustomerIfNotExistsAsync(OrderDto order, CancellationToken cancellationToken)
        {
            var customer = dbContext.Customers.ToList()
                .FirstOrDefault(c => c.Id.Value.CompareTo(order.Customer.CustomerGuid)==0);

            if (customer == null)
            {
                var newCustomer = Customer.Create(CustomerId.Of(order.Customer.CustomerGuid), order.Customer.Username, order.Customer.Email);

                dbContext.Customers.Add(newCustomer);
                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        private async void CreateProductsIfNotExistsAsync(OrderDto order, CancellationToken cancellationToken)
        {
            foreach (var orderItem in order.OrderItems)
            {
                if (!dbContext.Products.ToList().Any(p => p.Id.Value == orderItem.ProductId))
                {
                    var newProduct = Product.Create(ProductId.Of(orderItem.ProductId), orderItem.ProductName, orderItem.Price);
                    dbContext.Products.Add(newProduct);
                }
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }

        private Order CreateNewOrder(OrderDto orderDto)
        {
            var orderGuid = Guid.NewGuid();
            var shippingAddress = Address.Of(orderDto.ShippingAddress.FirstName, orderDto.ShippingAddress.LastName,
                orderDto.ShippingAddress.EmailAddress, orderDto.ShippingAddress.AddressLine, orderDto.ShippingAddress.Country,
                orderDto.ShippingAddress.State, orderDto.ShippingAddress.ZipCode);
            var billingAddress = Address.Of(orderDto.BillingAddress.FirstName, orderDto.BillingAddress.LastName,
                orderDto.BillingAddress.EmailAddress, orderDto.BillingAddress.AddressLine,
                orderDto.BillingAddress.Country, orderDto.BillingAddress.State, orderDto.BillingAddress.ZipCode);

            var newOrder = Order.Create(
                    id: OrderId.Of(orderGuid),
                    orderName: OrderName.Of($"ORDER_{GetNextOrderNumber()}"),
                    customerId: CustomerId.Of(orderDto.Customer.CustomerGuid),
                    shippingAddress: shippingAddress,
                    billingAddress: billingAddress,
                    payment: Payment.Of(orderDto.Payment.CardName, orderDto.Payment.CardNumber, orderDto.Payment.Expiration,
                        orderDto.Payment.Cvv, orderDto.Payment.PaymentMethod)
            );

            foreach (var orderItemDto in orderDto.OrderItems)
            {
                newOrder.Add(ProductId.Of(orderItemDto.ProductId), orderItemDto.Quantity, orderItemDto.Price);
            }

            return newOrder;
        }

        private int GetNextOrderNumber()
        {
            var orderNumber = dbContext.Orders.ToList()?
                .Select(o => int.Parse(o.OrderName.Value.Replace("ORDER_", "")))
                .Max();

            if (orderNumber != null)
            {
                return (int)orderNumber + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
