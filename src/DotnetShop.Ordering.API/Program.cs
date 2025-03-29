using DotnetShop.Ordering.API;
using DotnetShop.Ordering.API.Endpoints;
using DotnetShop.Ordering.Application;
using DotnetShop.Ordering.Infrastructure;
using DotnetShop.Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

app.UseApiServices();

app.AddGetOrdersEndpoint();
app.AddGetOrdersByCustomerEndpoint();
app.AddGetOrdersByNameEndpoint();
app.AddCreateOrderEndpoint();
app.AddUpdateOrderEndpoint();
app.AddDeleteOrderEndpoint();


if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
