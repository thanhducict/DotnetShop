using DotnetShop.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient<ICatalogService, CatalogService>(httpClient =>
{
    httpClient.BaseAddress = new Uri(builder.Configuration["ServiceUri:Catalog"]!);
});

builder.Services.AddAuthentication("MyBearerScheme");

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();
