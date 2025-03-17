namespace DotnetShop.Catalog.API.Features.Products.GetProductById
{
    public record GetProductByIdResponse(Product Products);

    public static class GetProductByIdEndpoint
    {
        public static void AddGetProductByIdEndpoint(this WebApplication app)
        {
            app.MapGet("products/{id}",
                async (int id, ISender sender) =>
                {
                    var query = new GetProductByIdQuery(id);

                    var result = await sender.Send(query);

                    return new GetProductByIdResponse(result.Product);
                })
                .WithName("GetProductById")
                .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Product By Id")
                .WithDescription("Get Product By Id");
        }
    }
}
