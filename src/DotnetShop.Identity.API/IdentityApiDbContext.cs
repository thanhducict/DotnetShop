using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

internal class IdentityApiDbContext : IdentityDbContext
{
    public IdentityApiDbContext(DbContextOptions<IdentityApiDbContext> options)
            : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>().HasData(new ApplicationUser
        {
            Id = new Guid("96dcde91-3428-4a46-b61c-d1f88e74be4e").ToString(),
            UserName = "admin",
            Email = "admin@dotnetshop.com"
        });

        builder.Entity<CustomerUser>().HasData(new CustomerUser
        {
            Id = new Guid("0912b826-7fd9-46c1-b08f-986c28f22558").ToString(),
            UserName = "rooney",
            Email = "wayne.rooney@manutd.com",
            FirstName = "Wayne",
            LastName = "Rooney",
            Gender = true,
            AddressLine = "5 Storeton Road",
            Country = "England",
            State = "Merseyside",
            ZipCode = "38050",
        });

        builder.Entity<CustomerUser>().HasData(new CustomerUser
        {
            Id = new Guid("108b9eb5-1eff-47f3-b328-7bf498b4145d").ToString(),
            UserName = "scholes",
            Email = "paul.scholes@manutd.com",
            FirstName = "Paul",
            LastName = "Scholes",
            Gender = true,
            AddressLine = "1 Oxford Street",
            Country = "England",
            State = "Nottingham",
            ZipCode = "08050",
        });

        base.OnModelCreating(builder);
    }
}
