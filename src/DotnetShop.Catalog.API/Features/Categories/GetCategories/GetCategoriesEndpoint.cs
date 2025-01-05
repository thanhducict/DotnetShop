namespace DotnetShop.Catalog.API.Features.Categories.GetCategories
{
    public record GetCategoriesRequest();

    public record GetCategoriesResponse(IEnumerable<Category> Categories);

    public static class GetCategoriesEndpoint
    {
        public static void AddGetCategoriesEndpoint(this WebApplication app)
        {
            app.MapGet("categories",
                async ([AsParameters] GetCategoriesRequest request, ISender sender) =>
                {
                    var query = new GetCategoriesQuery();

                    var result = await sender.Send(query);

                    var response = new GetCategoriesResponse(result.Categories);

                    return Results.Ok(response);
                })
                .WithName("GetCategories")
                .Produces<GetCategoriesResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Categories")
                .WithDescription("Get Categories");
        }
    }
}
