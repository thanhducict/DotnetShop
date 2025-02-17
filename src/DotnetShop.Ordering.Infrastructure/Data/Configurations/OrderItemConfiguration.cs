using DotnetShop.Ordering.Domain.Models;
using DotnetShop.Ordering.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetShop.Ordering.Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Id).HasConversion(
                                       orderItemId => orderItemId.Value,
                                       dbId => OrderItemId.Of(dbId));

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            builder.Property(oi => oi.Quantity).IsRequired();

            builder.Property(oi => oi.Price).IsRequired();
        }
    }
}
