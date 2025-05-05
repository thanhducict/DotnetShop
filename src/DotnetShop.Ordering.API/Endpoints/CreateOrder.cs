using DotnetShop.Common.CQRS;
using DotnetShop.Ordering.Application.Dtos;
using DotnetShop.Ordering.Application.Orders.Commands.CreateOrder;

namespace DotnetShop.Ordering.API.Endpoints
{
    public record CreateOrderRequest(OrderDto Order);
    public record CreateOrderResponse(Guid Id);

    public static class CreateOrder
    {
        public static void AddCreateOrderEndpoint(this WebApplication app)
        {
            app.MapPost("orders", async (CreateOrderRequest request, IRequestDispatcher dispatcher) =>
            {
                var command = new CreateOrderCommand(request.Order);

                var result = await dispatcher.DispatchAsync(command);

                var response = new CreateOrderResponse(result.Id);

                return Results.Created($"/orders/{response.Id}", response);

            })
            .WithName("CreateOrder")
            .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Order")
            .WithDescription("Create Order");
        }
    }
}
