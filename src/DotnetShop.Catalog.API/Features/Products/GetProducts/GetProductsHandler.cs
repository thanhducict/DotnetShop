using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Products.GetProducts
{
    public record GetProductsQuery(int PageNumber = 1, int PageSize = 10) : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products, PagingInfo PagingInfo);

    internal class GetProductsQueryHandler(IProductRepository productRepository,
        ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle called with {@Query}", query);

            var products = await productRepository.GetProducts(query.PageNumber, query.PageSize, cancellationToken);
            var totalItems = await productRepository.GetTotalProducts(cancellationToken);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = query.PageNumber,
                ItemsPerPage = query.PageSize,
                TotalItems = totalItems
            };

            return new GetProductsResult(products, pagingInfo);
        }
    }
}
