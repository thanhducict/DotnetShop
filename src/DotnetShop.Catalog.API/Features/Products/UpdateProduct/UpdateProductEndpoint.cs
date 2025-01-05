namespace DotnetShop.Catalog.API.Features.Products.UpdateProduct
{
    public record UpdateProductRequest(int ProductId, Guid ProductGuid, string ProductName, string ShortDescription, string LongDescription,
        List<string> ImageUrls, string ImageThumbnailUrl, decimal Price, int CategoryId);

    public record UpdateProductResponse(bool IsSuccess);

    public static class CreateProductEndpoint
    {
        public static void AddUpdateProductEndpoint(this WebApplication app)
        {
            app.MapPut("products",
                async (UpdateProductRequest request, ISender sender) =>
                {
                    var command = new UpdateProductCommand(
                        request.ProductId,
                        request.ProductGuid,
                        request.ProductName,
                        request.ShortDescription,
                        request.LongDescription,
                        request.ImageUrls,
                        request.ImageThumbnailUrl,
                        request.Price,
                        request.CategoryId
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
