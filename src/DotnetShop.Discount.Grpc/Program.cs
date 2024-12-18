using DotnetShop.Discount.Grpc.Repositories;
using DotnetShop.Discount.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddSingleton<IDiscountRepository, DiscountRepository>();

var app = builder.Build();

app.MapGrpcService<DiscountService>();
app.MapGet("/", () => "Discount Grpc");

app.Run();
