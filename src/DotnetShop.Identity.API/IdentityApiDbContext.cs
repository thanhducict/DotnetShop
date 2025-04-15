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
    }
}
