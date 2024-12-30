using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Catalog.API.Features.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Categories, string ShortDescription,
        string LongDescription, string ImageUrl, string ImageThumbnailUrl, decimal Price);

    public record CreateProductResponse(Guid Id);

    public static class CreateProductEndpoint
    {
        public static void AddCreateProductEndpoint(this WebApplication app)
        {
            app.MapPost("products",
                async ([FromBody] CreateProductRequest request, ISender sender) =>
                {
                    var command = new CreateProductCommand(
                        request.Name,
                        request.Categories,
                        request.ShortDescription,
                        request.LongDescription,
                        request.ImageUrl,
                        request.ImageThumbnailUrl,
                        request.Price
                    );

                    var result = await sender.Send(command);

                    var response = new CreateProductResponse(result.Id);

                    return Results.Created($"/products/{response.Id}", response);

                })
                .WithName("CreateProduct")
                .Produces<CreateProductResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Product")
                .WithDescription("Create Product");
        }
    }
}
