using DotnetShop.Catalog.API.Repositories;

namespace DotnetShop.Catalog.API.Features.Products.GetProductById
{
    public record GetProductByIdQuery(int ProductId) : IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Product Product);

    internal class GetProductByIdQueryHandler(IProductRepository productRepository, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);
            var product = await productRepository.GetProductById(query.ProductId, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(query.ProductId);
            }

            return new GetProductByIdResult(product);
        }
    }
}
