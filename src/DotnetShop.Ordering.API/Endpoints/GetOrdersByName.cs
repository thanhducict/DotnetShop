using DotnetShop.Common.CQRS;
using DotnetShop.Ordering.Application.Dtos;
using DotnetShop.Ordering.Application.Orders.Queries.GetOrdersByName;

namespace DotnetShop.Ordering.API.Endpoints
{
    public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);

    public static class GetOrdersByName
    {
        public static void AddGetOrdersByNameEndpoint(this WebApplication app)
        {
            app.MapGet("/orders/{orderName}", async (string orderName, IRequestDispatcher dispatcher) =>
                {
                    var command = new GetOrdersByNameQuery(orderName);

                    var result = await dispatcher.DispatchAsync(command);

                    var response = new GetOrdersByNameResponse(result.Orders);

                    return Results.Ok(response);

                })
                .WithName("GetOrdersByName")
                .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Get Orders By Name")
                .WithDescription("Get Orders By Name");
        }
    }
}
