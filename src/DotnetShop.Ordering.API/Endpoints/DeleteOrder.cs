using DotnetShop.Ordering.Application.Orders.Commands.DeleteOrder;
using MediatR;

namespace DotnetShop.Ordering.API.Endpoints
{
    public record DeleteOrderResponse(bool IsSuccess);

    public static class DeleteOrder
    {
        public static void AddDeleteOrderEndpoint(this WebApplication app)
        {
            app.MapDelete("orders/{id}", async (Guid id, ISender sender) =>
            {
                var command = new DeleteOrderCommand(id);

                var result = await sender.Send(command);

                var response = new DeleteOrderResponse(result.IsSuccess);

                return Results.Ok(response);

            })
            .WithName("DeleteOrder")
            .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Order")
            .WithDescription("Delete Order");
        }
    }
}
