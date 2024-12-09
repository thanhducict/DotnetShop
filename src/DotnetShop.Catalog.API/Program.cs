using DotnetShop.Catalog.API;
using DotnetShop.Catalog.API.Products.CreateProduct;
using DotnetShop.Catalog.API.Products.DeleteProduct;
using DotnetShop.Catalog.API.Products.GetProductById;
using DotnetShop.Catalog.API.Products.GetProducts;
using DotnetShop.Catalog.API.Products.GetProductsByCategory;
using DotnetShop.Catalog.API.Products.UpdateProduct;
using DotnetShop.Common.Behaviors;
using DotnetShop.Common.Exceptions.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CatalogDB")!);
}).UseLightweightSessions().InitializeWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks();

// Configure the HTTP request pipeline.
var app = builder.Build();

app.AddGetProductsEndpoint();
app.AddCreateProductEndpoint();
app.AddGetProductByIdEndpoint();
app.AddGetProductsByCategoryEndpoint();
app.AddUpdateProductEndpoint();
app.AddDeleteProductEndpoint();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health");

app.Run();
