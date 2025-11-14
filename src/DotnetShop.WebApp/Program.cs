using DotnetShop.WebApp;
using DotnetShop.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient<ICatalogService, CatalogService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ServiceUri:Catalog"]!);
});
builder.Services.AddHttpClient<IIdentityService, IdentityService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ServiceUri:Identity"]!);
});
builder.Services.AddHttpClient<ICartService, CartService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ServiceUri:ShoppingCart"]!);
});

builder.Services.AddAuthentication(Constants.MyBearerScheme).AddCookie(Constants.MyBearerScheme, options =>
{
    options.LoginPath = "/Account/Login"; // Default value, can omit
    options.LogoutPath = "/Account/Logout"; // Default value, can omit
    options.AccessDeniedPath = "/Account/NoPermission"; // Default value: Account/AccessDenided
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();
