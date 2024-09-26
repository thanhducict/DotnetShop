using DotnetShop.Catalog.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetShop.Catalog.API
{
    public class SeedData
    {
        public static async Task SeedAsync(CatalogDbContext catalogDbContext, ILogger logger)
        {
            await catalogDbContext.Database.EnsureCreatedAsync();

            try
            {
                // This won't run because Categories data was added during Model Seed
                if (!await catalogDbContext.Categories.AnyAsync())
                {
                    await catalogDbContext.Categories.AddRangeAsync(PopulateSampleCategories());
                    await catalogDbContext.SaveChangesAsync();
                }
                // Products data will be added at runtime
                if (!await catalogDbContext.Products.AnyAsync())
                {
                    await catalogDbContext.Products.AddRangeAsync(PopulateSampleProducts());
                    await catalogDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("End of data seeding.");
            }
        }

        private static IEnumerable<Category> PopulateSampleCategories()
        {
            return new List<Category> {
                new Category { CategoryName = "Shirt" },
                new Category { CategoryName = "Cup" },
                new Category { CategoryName = "Badge" }
            };
        }

        private static IEnumerable<Product> PopulateSampleProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductId = "1",
                    Name = "Kudu Purple Sweatshirt",
                    Price = 15.95M,
                    ImageUrl = "/images/Products/Kudu Purple Sweatshirt HD.png",
                    CategoryId = 1,
                },
                new Product
                {
                    ProductId = "2",
                    Name = ".NET Blue Sweatshirt",
                    Price = 18.95M,
                    ImageUrl = "/images/Products/NET Blue Sweatshirt.png",
                    CategoryId = 1,
                },
                new Product
                {
                    ProductId = "3",
                    Name = ".NET Bot Black Sweatshirt",
                    Price = 18.95M,
                    ImageUrl = "/images/Products/NET Bot Black Sweatshirt.png",
                    CategoryId = 1,
                },
                new Product
                {
                    ProductId = "4",
                    Name = ".NET Foundation Sweatshirt",
                    Price = 17.95M,
                    ImageUrl = "/images/Products/NET Foundation Sweatshirt.png",
                    CategoryId = 1,
                },
                new Product
                {
                    ProductId = "5",
                    Name = "Prism White T-Shirt",
                    Price = 18.95M,
                    ImageUrl = "/images/Products/Prism White T-Shirt.png",
                    CategoryId = 1,
                },
                new Product
                {
                    ProductId = "6",
                    Name = "Roslyn Red T-Shirt",
                    Price = 17.95M,
                    ImageUrl = "/images/Products/Roslyn Red T-Shirt.png",
                    CategoryId = 1,
                },
                new Product
                {
                    ProductId = "7",
                    Name = "Cup<T> T-Shirt",
                    Price = 17.95M,
                    ImageUrl = "/images/Products/CupT T-Shirt.png",
                    CategoryId = 1,
                },
                new Product
                {
                    ProductId = "8",
                    Name = "Cup<T> White Mug",
                    Price = 17.95M,
                    ImageUrl = "/images/Products/CupT White Mug.png",
                    CategoryId = 2,
                },
                new Product
                {
                    ProductId = "9",
                    Name = ".NET Black White Mug",
                    Price = 17.95M,
                    ImageUrl = "/images/Products/NET Black White Mug.png",
                    CategoryId = 2,
                },
                new Product
                {
                    ProductId = "10",
                    Name = "Cup<T> Badge",
                    Price = 17.95M,
                    ImageUrl = "/images/Products/CupT Badge.png",
                    CategoryId = 3,
                },
                new Product
                {
                    ProductId = "11",
                    Name = "NET Foundation Badge",
                    Price = 17.95M,
                    ImageUrl = "/images/Products/NET Foundation Badge.png",
                    CategoryId = 3,

                },
                new Product
                {
                    ProductId = "12",
                    Name = "Roslyn Red Badge",
                    Price = 17.95M,
                    ImageUrl = "/images/Products/Roslyn Red Badge.png",
                    CategoryId = 3,
                }
            };
        }
    }
}
