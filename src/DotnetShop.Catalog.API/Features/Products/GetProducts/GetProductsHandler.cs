using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Products.GetProducts
{
    public record GetProductsQuery(int PageNumber = 1, int PageSize = 10) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler(IProductRepository productRepository,
        IConfiguration configuration,
        ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);
            var products = await productRepository.GetProducts(query.PageNumber, query.PageSize, cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
