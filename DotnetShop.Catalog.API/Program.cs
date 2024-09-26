using DotnetShop.Catalog.API;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddDbContext<CatalogDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("SqlServer")));

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Policy1",
            policy =>
            {
                policy.WithOrigins("*")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("x-pagination");
            });
    });
}
else
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("Policy1",
            policy =>
            {
                policy.WithOrigins("https://brave-plant-0b993dd00.3.azurestaticapps.net")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("x-pagination");
            });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var context = scopedProvider.GetRequiredService<CatalogDbContext>();

        await SeedData.SeedAsync(context, app.Logger);
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.Run();
