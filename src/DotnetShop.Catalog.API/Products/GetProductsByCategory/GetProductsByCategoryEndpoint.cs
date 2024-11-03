using DotnetShop.Catalog.API.Models;

namespace DotnetShop.Catalog.API.Products.GetProductsByCategory
{
    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);

    public static class GetProductsByCategoryEndpoint
    {
        public static void AddGetProductsByCategoryEndpoint(this WebApplication app)
        {
            app.MapGet("products/category/{category}",
                async (string category, ISender sender) =>
                {
                    var query = new GetProductsByCategoryQuery(category);

                    var result = await sender.Send(query);

                    return new GetProductsByCategoryResponse(result.Products);
                })
                .WithName("GetProductsByCategory")
                .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Products By Category")
                .WithDescription("Get Products By Category");
        }
    }
}
