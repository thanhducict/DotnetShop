using DotnetShop.Ordering.Application.Dtos;
using DotnetShop.Ordering.Application.Orders.Commands.CreateOrder;
using MediatR;

namespace DotnetShop.Ordering.API.Endpoints
{
    public record CreateOrderRequest(OrderDto Order);
    public record CreateOrderResponse(Guid Id);

    public class TestDto
    {
        public string Test { get; set; }
    }

    public static class CreateOrder
    {
        public static void AddCreateOrderEndpoint(this WebApplication app)
        {
            app.MapPost("orders", async (CreateOrderRequest request, ISender sender) =>
            {
                var command = new CreateOrderCommand(request.Order);

                var result = await sender.Send(command);

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
