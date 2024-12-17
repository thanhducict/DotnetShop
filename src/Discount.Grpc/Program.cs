using Discount.Grpc.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

builder.Services.AddSingleton<IDiscountRepository, DiscountRepository>();

var app = builder.Build();

//app.MapGrpcService<GreeterService>();
app.MapGrpcReflectionService();
app.MapGet("/", () => "Discount Grpc");

app.Run();
