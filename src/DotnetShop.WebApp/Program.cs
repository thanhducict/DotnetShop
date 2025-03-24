using DotnetShop.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddSingleton<ICatalogService, CatalogService>();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

app.Run();
