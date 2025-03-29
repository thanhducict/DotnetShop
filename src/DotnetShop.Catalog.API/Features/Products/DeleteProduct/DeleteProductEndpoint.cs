using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Catalog.API.Features.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuccess);

    public static class DeleteroductEndpoint
    {
        public static void AddDeleteProductEndpoint(this WebApplication app)
        {
            app.MapDelete("products/{productId}",
                async (int productId, ISender sender) =>
                {
                    var command = new DeleteProductCommand(productId);

                    var result = await sender.Send(command);

                    var response = new DeleteProductResponse(result.IsSuccess);

                    return Results.Ok(response);

                })
                .WithName("DeleteProduct")
                .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Delete Product")
                .WithDescription("Delete Product");
        }
    }
}
