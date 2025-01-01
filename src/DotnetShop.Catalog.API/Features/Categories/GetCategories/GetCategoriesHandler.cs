using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Categories.GetCategories
{
    public record GetCategoriesQuery : IQuery<GetCategoriesResult>;
    public record GetCategoriesResult(IEnumerable<Category> Categories);

    internal class GetCategoriesQueryHandler(ICategoryRepository categoryRepository, ILogger<GetCategoriesQueryHandler> logger)
        : IQueryHandler<GetCategoriesQuery, GetCategoriesResult>
    {
        public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetCategoriesQueryHandler.Handle called with {@Query}", query);
            var categories = await categoryRepository.GetCategories(cancellationToken);

            return new GetCategoriesResult(categories);
        }
    }
}
