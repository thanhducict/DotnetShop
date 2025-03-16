namespace DotnetShop.Catalog.API.Features.Products.GetProductByGuid
{
    public record GetProductByGuidResponse(Product Products);

    public static class GetProductByGuidEndpoint
    {
        public static void AddGetProductByGuidEndpoint(this WebApplication app)
        {
            app.MapGet("products/{guid}",
                async (int guid, ISender sender) =>
                {
                    var query = new GetProductByGuidQuery(guid);

                    var result = await sender.Send(query);

                    return new GetProductByGuidResponse(result.Product);
                })
                .WithName("GetProductById")
                .Produces<GetProductByGuidResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product By Guid")
                .WithDescription("Get Product By Guid");
        }
    }
}
