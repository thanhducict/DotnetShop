using DotnetShop.Identity.API;
using DotnetShop.Identity.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddScoped<DotnetShop.Identity.API.Services.IAuthenticationService,
    DotnetShop.Identity.API.Services.AuthenticationService>();
builder.Services.AddScoped<DotnetShop.Identity.API.Services.IJwtTokenGenerator,
    DotnetShop.Identity.API.Services.JwtTokenGenerator>();

builder.Services.AddAuthentication("MyBearerScheme").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JwtTokenSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtTokenSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.ASCII.GetBytes(builder.Configuration["JwtTokenSettings:SecretForKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

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
