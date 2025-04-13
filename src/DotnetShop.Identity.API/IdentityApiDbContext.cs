using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class IdentityApiDbContext : IdentityDbContext
{
    public IdentityApiDbContext(DbContextOptions<IdentityApiDbContext> options)
            : base(options)
    {
    }
}
