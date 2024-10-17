using DotnetShop.Catalog.API.Products.CreateProduct;
using DotnetShop.Catalog.API.Products.GetProducts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CatalogDB")!);
}).UseLightweightSessions();

// Configure the HTTP request pipeline.
var app = builder.Build();

app.AddGetProductsEndpoint();
app.AddCreateProductEndpoint();

app.Run();
