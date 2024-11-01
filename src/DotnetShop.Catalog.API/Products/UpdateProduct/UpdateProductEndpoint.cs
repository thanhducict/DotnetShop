namespace DotnetShop.Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Categories, string Description, string ImageFile, decimal Price);

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
                        request.Description,
                        request.ImageFile,
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
