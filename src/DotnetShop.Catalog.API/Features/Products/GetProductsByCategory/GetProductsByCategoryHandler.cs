using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Products.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(string CategoryName) : IQuery<GetProductsByCategoryResult>;

    public record GetProductsByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductsByCategoryQueryHandler(IProductRepository productRepository, ILogger<GetProductsByCategoryQueryHandler> logger)
        : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
    {
        public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsByCategoryQueryHandler.Handle called with {@Query}", query);
            var products = await productRepository.GetProductsByCategory(query.CategoryName, cancellationToken);

            return new GetProductsByCategoryResult(products);
        }
    }
}
