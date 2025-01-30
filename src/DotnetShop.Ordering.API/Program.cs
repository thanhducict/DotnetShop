using DotnetShop.Ordering.API;
using DotnetShop.Ordering.Application;
using DotnetShop.Ordering.Infrastructure;
using DotnetShop.Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
