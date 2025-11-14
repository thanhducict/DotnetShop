namespace DotnetShop.Catalog.API.Features.Products.GetProducts
{
    public record GetProductsRequest(int PageNumber = 1, int PageSize = 10);

    public record GetProductsResponse(IEnumerable<Product> Products, PagingInfo PagingInfo);

    public static class GetProductsEndpoint
    {
        public static void AddGetProductsEndpoint(this WebApplication app)
        {
            app.MapGet("products",
                async ([AsParameters] GetProductsRequest request, IRequestDispatcher dispatcher) =>
                {
                    var query = new GetProductsQuery
                    {
                        PageNumber = request.PageNumber,
                        PageSize = request.PageSize,
                    };

                    var result = await dispatcher.DispatchAsync(query);

                    var response = new GetProductsResponse(result.Products, result.PagingInfo);

                    return Results.Ok(response);
                })
                .WithName("GetProducts")
                .Produces<GetProductsResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Products")
                .WithDescription("Get Products");
        }
    }
}
