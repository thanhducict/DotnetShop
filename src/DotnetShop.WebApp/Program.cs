using DotnetShop.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<IHttpClientFactoryBase, HttpClientFactoryBase>();
builder.Services.AddSingleton<ICatalogService, CatalogService>();

builder.Services.AddAuthentication("MyBearerScheme");

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

app.Run();
