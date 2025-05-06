using DotnetShop.Common.CQRS;
using DotnetShop.Ordering.Application.Dtos;
using DotnetShop.Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace DotnetShop.Ordering.API.Endpoints
{
    public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);

    public static class GetOrdersByCustomer
    {
        public static void AddGetOrdersByCustomerEndpoint(this WebApplication app)
        {
            app.MapGet("/orders/customer/{customerId}", async (Guid customerId, IRequestDispatcher dispatcher) =>
                {
                    var command = new GetOrdersByCustomerQuery(customerId);

                    var result = await dispatcher.DispatchAsync(command);

                    var response = new GetOrdersByCustomerResponse(result.Orders);

                    return Results.Ok(response);

                })
                .WithName("GetOrdersByCustomer")
                .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithSummary("Get Orders By Customer")
                .WithDescription("Get Orders By Customer");
        }
    }
}
