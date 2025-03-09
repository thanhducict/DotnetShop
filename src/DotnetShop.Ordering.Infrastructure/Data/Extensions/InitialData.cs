using DotnetShop.Ordering.Domain.Models;
using DotnetShop.Ordering.Domain.ValueObjects;

namespace DotnetShop.Ordering.Infrastructure.Data.Extensions
{
    internal class InitialData
    {
        public static IEnumerable<Customer> Customers =>
        [
            Customer.Create(CustomerId.Of(new Guid("0912b826-7fd9-46c1-b08f-986c28f22558")), "rooney", "wayne.rooney@manutd.com"),
            Customer.Create(CustomerId.Of(new Guid("108b9eb5-1eff-47f3-b328-7bf498b4145d")), "scholes", "paul.scholes@manutd.com")
        ];

        public static IEnumerable<Product> Products =>
            [
                Product.Create(ProductId.Of(new Guid("51149bd0-c9e0-4068-b8f2-3368caa5c85c")), ".NET Blue Sweatshirt", 18.95M),
                Product.Create(ProductId.Of(new Guid("293d91cd-0de8-4b18-b2e9-a1a26678dada")), ".NET Foundation Sweatshirt", 17.95M),
                Product.Create(ProductId.Of(new Guid("90e3af6d-e79a-45b6-b2c8-8bc25f60708a")), ".NET Foundation Badge", 3.95M),
                Product.Create(ProductId.Of(new Guid("324a1f34-97f9-4636-be93-ec456b19f90e")), "Roslyn Red Badge", 3.95M)
            ];

        public static IEnumerable<Order> OrdersWithItems
        {
            get
            {
                var address1 = Address.Of("Wayne", "Rooney", "wayne.rooney@gmail.com", "5 Storeton Road", "England", "Merseyside", "38050");
                var address2 = Address.Of("Paul", "Scholes", "paul.scholes@gmail.com", "1 Oxford Street", "England", "Nottingham", "08050");

                var payment1 = Payment.Of("Rooney", "5555333322226666", "12/28", "355", 1);
                var payment2 = Payment.Of("Scholes", "8888999955559999", "06/30", "222", 2);

                var order1 = Order.Create(
                    OrderId.Of(new Guid("3a347392-c092-4755-89e9-9fa47b9d3ccb")),
                    CustomerId.Of(new Guid("0912b826-7fd9-46c1-b08f-986c28f22558")),
                    OrderName.Of("ORDER_1"),
                    shippingAddress: address1,
                    billingAddress: address1,
                    payment1);
                order1.Add(ProductId.Of(new Guid("51149bd0-c9e0-4068-b8f2-3368caa5c85c")), 2, 37.9M);
                order1.Add(ProductId.Of(new Guid("293d91cd-0de8-4b18-b2e9-a1a26678dada")), 1, 17.95M);

                var order2 = Order.Create(
                    OrderId.Of(new Guid("9a6cd49e-c1db-4ed1-951b-bc5ac0568b45")),
                    CustomerId.Of(new Guid("108b9eb5-1eff-47f3-b328-7bf498b4145d")),
                    OrderName.Of("ORDER_2"),
                    shippingAddress: address2,
                    billingAddress: address2,
                    payment2);
                order2.Add(ProductId.Of(new Guid("90e3af6d-e79a-45b6-b2c8-8bc25f60708a")), 1, 7.9M);
                order2.Add(ProductId.Of(new Guid("324a1f34-97f9-4636-be93-ec456b19f90e")), 2, 450);

                return new List<Order> { order1, order2 };
            }
        }
    }
}
