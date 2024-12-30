namespace DotnetShop.Catalog.API.Features.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Categories, string ShortDescription,
        string LongDescription, string ImageUrl, string ImageThumbnailUrl, decimal Price);

    public record UpdateProductResponse(bool IsSuccess);

    public static class CreateProductEndpoint
    {
        public static void AddUpdateProductEndpoint(this WebApplication app)
        {
            app.MapPut("products",
                async (UpdateProductRequest request, ISender sender) =>
                {
                    var command = new UpdateProductCommand(
                        request.Id,
                        request.Name,
                        request.Categories,
                        request.ShortDescription,
                        request.LongDescription,
                        request.ImageUrl,
                        request.ImageThumbnailUrl,
                        request.Price
                    );

                    var result = await sender.Send(command);

                    var response = new UpdateProductResponse(true);

                    return Results.Ok(response);

                })
                .WithName("UpdateProduct")
                .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Update Product")
                .WithDescription("Update Product");
        }
    }
}
