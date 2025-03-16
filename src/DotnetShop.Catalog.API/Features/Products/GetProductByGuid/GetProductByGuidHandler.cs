using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Products.GetProductByGuid
{
    public record GetProductByGuidQuery(int ProductId) : IQuery<GetProductByGuidResult>;

    public record GetProductByGuidResult(Product Product);

    internal class GetProductByGuidQueryHandler(IProductRepository productRepository, ILogger<GetProductByGuidQueryHandler> logger) : IQueryHandler<GetProductByGuidQuery, GetProductByGuidResult>
    {
        public async Task<GetProductByGuidResult> Handle(GetProductByGuidQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByGuidQueryHandler.Handle called with {@Query}", query);
            var product = await productRepository.GetProductById(query.ProductId, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(query.ProductId);
            }

            return new GetProductByGuidResult(product);
        }
    }
}
