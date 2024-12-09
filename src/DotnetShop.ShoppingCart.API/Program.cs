using DotnetShop.Common.Behaviors;
using DotnetShop.Common.Exceptions.Handlers;
using DotnetShop.ShoppingCart.API.Repositories;
using Marten;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("CartDB")!);
    options.Schema.For<Cart>().Identity(x => x.Username);
}).UseLightweightSessions();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapControllers();
app.UseExceptionHandler(options => { });

app.Run();
