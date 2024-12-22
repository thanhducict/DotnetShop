using DotnetShop.Discount.Grpc;
using DotnetShop.Discount.Grpc.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddDbContext<DiscountContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DiscountDb"));
});

var app = builder.Build();

app.MapGrpcService<DiscountService>();
app.MapGet("/", () => "Discount Grpc");

app.InitialDatabase();

app.Run();
