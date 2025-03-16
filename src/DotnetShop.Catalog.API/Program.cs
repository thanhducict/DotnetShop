using DotnetShop.Catalog.API.Features.Categories.CreateCategory;
using DotnetShop.Catalog.API.Features.Categories.GetCategories;
using DotnetShop.Catalog.API.Features.Products.CreateProduct;
using DotnetShop.Catalog.API.Features.Products.DeleteProduct;
using DotnetShop.Catalog.API.Features.Products.GetProductByGuid;
using DotnetShop.Catalog.API.Features.Products.GetProducts;
using DotnetShop.Catalog.API.Features.Products.GetProductsByCategory;
using DotnetShop.Catalog.API.Features.Products.UpdateProduct;
using DotnetShop.Catalog.API.Repositories;
using DotnetShop.Common.Behaviors;
using DotnetShop.Common.Exceptions.Handlers;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks();

// Configure the HTTP request pipeline.
var app = builder.Build();

app.AddGetCategoriesEndpoint();
app.AddCreateCategoryEndpoint();

app.AddGetProductsEndpoint();
app.AddCreateProductEndpoint();
app.AddGetProductByGuidEndpoint();
app.AddGetProductsByCategoryEndpoint();
app.AddUpdateProductEndpoint();
app.AddDeleteProductEndpoint();

app.UseExceptionHandler(options => { });

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();
