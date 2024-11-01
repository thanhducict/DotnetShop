using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Catalog.API.Products.DeleteProduct
{
    public record DeleteProductRequest(Guid Id);

    public record DeleteProductResponse(bool IsSuccess);

    public static class DeleteroductEndpoint
    {
        public static void AddDeleteProductEndpoint(this WebApplication app)
        {
            app.MapDelete("products",
                async ([FromBody] DeleteProductRequest request, ISender sender) =>
                {
                    var command = new DeleteProductCommand(request.Id);

                    var result = await sender.Send(command);

                    var response = new DeleteProductResponse(true);

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
