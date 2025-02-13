using DotnetShop.Ordering.Application.Dtos;
using DotnetShop.Ordering.Application.Orders.Queries.GetOrdersByName;
using MediatR;

namespace DotnetShop.Ordering.API.Endpoints
{
    public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);

    public static class GetOrdersByName
    {
        public static void AddGetOrdersByNameEndpoint(this WebApplication app)
        {
            app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
                {
                    var command = new GetOrdersByNameQuery(orderName);

                    var result = await sender.Send(command);

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
