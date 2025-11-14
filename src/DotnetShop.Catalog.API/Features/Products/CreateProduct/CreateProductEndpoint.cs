using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Catalog.API.Features.Products.CreateProduct
{
    public record CreateProductRequest(Guid ProductGuid, string ProductName, string ShortDescription, string LongDescription,
        List<string> ImageUrls, string ImageThumbnailUrl, decimal Price, int CategoryId);

    public record CreateProductResponse(int ProductId);

    public static class CreateProductEndpoint
    {
        public static void AddCreateProductEndpoint(this WebApplication app)
        {
            app.MapPost("products",
                async ([FromBody] CreateProductRequest request, IRequestDispatcher dispatcher) =>
                {
                    var command = new CreateProductCommand(
                        request.ProductGuid,
                        request.ProductName,
                        request.ShortDescription,
                        request.LongDescription,
                        request.ImageUrls,
                        request.ImageThumbnailUrl,
                        request.Price,
                        request.CategoryId
                    );

                    var result = await dispatcher.DispatchAsync(command);

                    var response = new CreateProductResponse(result.ProductId);

                    return Results.Created($"/products/{response.ProductId}", response);

                })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
        }
    }
}
