using DotnetShop.Common.Behaviors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});


var app = builder.Build();
app.MapControllers();

app.Run();
