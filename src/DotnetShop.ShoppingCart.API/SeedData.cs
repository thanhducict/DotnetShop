using DotnetShop.ShoppingCart.API.Repositories;
using Marten;

namespace DotnetShop.ShoppingCart.API
{
    internal class SeedData
    {
        internal static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var cartRepository = scope.ServiceProvider.GetRequiredService<ICartRepository>();
            var cart = new Cart("rooney")
            {
                Items = new List<CartItem>
                {
                    new CartItem
                    {
                        ProductGuid = new Guid("28d65b5d-f522-448c-8ce5-203e4efe2c17"),
                        ProductName = "Kudu Purple Sweatshirt",
                        Quantity = 5,
                        Price = 19.99m
                    },
                    new CartItem
                    {
                        ProductGuid = new Guid("51149bd0-c9e0-4068-b8f2-3368caa5c85c"),
                        ProductName = ".NET Blue Sweatshirt",
                        Quantity = 10,
                        Price = 9.99m
                    }
                }
            };
            await cartRepository.StoreCart(cart);
        }
    }
}
