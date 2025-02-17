using DotnetShop.Ordering.Application.Dtos;
using DotnetShop.Ordering.Application.Orders.Commands.UpdateOrder;
using MediatR;

namespace DotnetShop.Ordering.API.Endpoints
{
    public record UpdateOrderRequest(OrderDto Order);
    public record UpdateOrderResponse(bool IsSuccess);

    public static class UpdateOrder
    {
        public static void AddUpdateOrderEndpoint(this WebApplication app)
        {
            app.MapPut("orders", async (UpdateOrderRequest request, ISender sender) =>
            {
                var command = new UpdateOrderCommand(request.Order);

                var result = await sender.Send(command);

                var response = new UpdateOrderResponse(result.IsSuccess);

                return Results.Ok(response);

            })
            .WithName("UpdateOrder")
            .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Order")
            .WithDescription("Update Order");
        }
    }
}
