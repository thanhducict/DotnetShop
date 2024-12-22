using DotnetShop.Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetShop.Discount.Grpc
{
    public class DiscountContext : DbContext
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        public DiscountContext(DbContextOptions<DiscountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductId = new Guid("a8814752-c866-4944-8020-61279d380087"), Description = "Discount for Cup<T> White Mug", Amount = 2M },
                new Coupon { Id = 2, ProductId = new Guid("03eb5b7c-3e42-4361-8210-3cb6ce0cf88f"), Description = "Discount for .NET Black White Mug", Amount = 2M }
            );
        }
    }
}
