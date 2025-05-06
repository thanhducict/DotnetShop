using DotnetShop.Common.CQRS;
using DotnetShop.Common.Pagination;
using DotnetShop.Ordering.Application.Dtos;
using DotnetShop.Ordering.Application.Orders.Queries.GetOrders;

namespace DotnetShop.Ordering.API.Endpoints
{
    public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);

    public static class GetOrders
    {
        public static void AddGetOrdersEndpoint(this WebApplication app)
        {
            app.MapGet("orders", async ([AsParameters] PaginationRequest request, IRequestDispatcher dispatcher) =>
                {
                    var command = new GetOrdersQuery(request);

                    var result = await dispatcher.DispatchAsync(command);

                    var response = new GetOrdersResponse(result.Orders);

                    return Results.Ok(response);

                })
                .WithName("GetOrders")
                .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Get Orders")
                .WithDescription("Get Orders");
        }
    }
}
