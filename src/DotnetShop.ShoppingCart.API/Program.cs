using DotnetShop.Common;
using DotnetShop.Common.Behaviors;
using DotnetShop.Common.Exceptions.Handlers;
using DotnetShop.Common.Messaging;
using DotnetShop.Discount.Grpc;
using DotnetShop.ShoppingCart.API.Producers;
using DotnetShop.ShoppingCart.API.Repositories;
using HealthChecks.UI.Client;
using Marten;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCommon();

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CartDB")!);
    options.Schema.For<Cart>().Identity(x => x.Username);
}).UseLightweightSessions();

builder.Services.AddScoped<CartRepository>();

builder.Services.AddScoped<ICartRepository>(provider =>
{
    var cartRepository = provider.GetRequiredService<CartRepository>();
    var distributedCache = provider.GetRequiredService<IDistributedCache>();

    return new CachedCartRepository(cartRepository, distributedCache);
});
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
{
    options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]);
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback =
        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };

    return handler;
});

builder.Services.AddMessageBrooker(builder.Configuration);
builder.Services.AddSingleton<CartCheckoutProducer>();

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("CartDB")!)
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!);

var app = builder.Build();

app.MapControllers();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();
