using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Catalog.API.Features.Categories.CreateCategory
{
    public record CreateCategoryRequest(string CategoryName);

    public record CreateCategoryResponse(Guid? CategoryId);

    public static class CreateCategoryEndpoint
    {
        public static void AddCreateCategoryEndpoint(this WebApplication app)
        {
            app.MapPost("categories",
                async ([FromBody] CreateCategoryRequest request, ISender sender) =>
                {
                    var command = new CreateCategoryCommand(
                        request.CategoryName
                    );

                    var result = await sender.Send(command);

                    var response = new CreateCategoryResponse(result.CategoryId);

                    return Results.Created($"/categories/{response.CategoryId}", response);

                })
                .WithName("CreateCategory")
                .Produces<CreateCategoryResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create Category")
                .WithDescription("Create Category");
        }
    }
}
