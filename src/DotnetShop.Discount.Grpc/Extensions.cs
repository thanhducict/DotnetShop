namespace DotnetShop.Discount.Grpc
{
    internal static class Extensions
    {
        internal static void InitialDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();

            if (!Directory.Exists("App_Data"))
            {
                Directory.CreateDirectory("App_Data");
            }

            dbContext.Database.EnsureCreated();
        }
    }
}
