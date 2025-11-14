using DotnetShop.Catalog.API;
using DotnetShop.Catalog.API.Features.Categories.CreateCategory;
using DotnetShop.Catalog.API.Features.Categories.GetCategories;
using DotnetShop.Catalog.API.Features.Products.CreateProduct;
using DotnetShop.Catalog.API.Features.Products.DeleteProduct;
using DotnetShop.Catalog.API.Features.Products.GetProductById;
using DotnetShop.Catalog.API.Features.Products.GetProducts;
using DotnetShop.Catalog.API.Features.Products.GetProductsByCategory;
using DotnetShop.Catalog.API.Features.Products.UpdateProduct;
using DotnetShop.Catalog.API.Repositories;
using DotnetShop.Common;
using DotnetShop.Common.Behaviors;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCommon();
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AddHostUrlToImageUrlsBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddHealthChecks();

// Configure the HTTP request pipeline.
var app = builder.Build();

app.AddGetCategoriesEndpoint();
app.AddCreateCategoryEndpoint();

app.AddGetProductsEndpoint();
app.AddCreateProductEndpoint();
app.AddGetProductByIdEndpoint();
app.AddGetProductsByCategoryEndpoint();
app.AddUpdateProductEndpoint();
app.AddDeleteProductEndpoint();

app.UseExceptionHandler(options => { });
app.UseStaticFiles();
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();
