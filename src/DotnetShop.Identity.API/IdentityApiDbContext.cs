using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetShop.Identity.API
{
    public class IdentityApiDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityApiDbContext(DbContextOptions<IdentityApiDbContext> options)
                : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().OwnsOne(u => u.ShippingAddress);
            builder.Entity<ApplicationUser>().OwnsOne(u => u.BillingAddress);
            builder.Entity<ApplicationUser>().OwnsOne(u => u.Payment);
        }
    }
}
