using DotnetShop.Identity.API;
using DotnetShop.Identity.API.Models;
using DotnetShop.Identity.API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHealthChecks();

builder.Services.AddDbContext<IdentityApiDbContext>(option =>
{
    option.UseSqlite(builder.Configuration.GetConnectionString("IdentityDb"));
});

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = true;
}).AddRoles<IdentityRole>()
.AddEntityFrameworkStores<IdentityApiDbContext>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddScoped<IAppAuthenticationService, AppAuthenticationService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IProfileService, ProfileService>();

var app = builder.Build();

app.Logger.LogInformation("Seeding Database...");
using var scope = app.Services.CreateScope();
var scopedProvider = scope.ServiceProvider;
try
{
    var context = scopedProvider.GetRequiredService<IdentityApiDbContext>();
    var userManager = scopedProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole>>();

    if (!Directory.Exists("App_Data"))
    {
        Directory.CreateDirectory("App_Data");
    }

    await context.Database.EnsureCreatedAsync();
    await SeedData.AddSampleRoles(roleManager);
    await SeedData.AddSampleUsers(userManager);
}
catch (Exception ex)
{
    app.Logger.LogError(ex, "An error occurred seeding the DB.");
}

app.MapControllers();
app.UseHealthChecks("/health");

app.Run();
