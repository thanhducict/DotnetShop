using Discount.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();
var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGrpcReflectionService();
app.MapGet("/", () => "Hello World!");

app.Run();
