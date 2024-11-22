using DotnetShop.Catalog.API.Infrastructure;

namespace DotnetShop.Catalog.API.Products.GetProductsByCategory
{
    public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryResult>;

    public record GetProductsByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger)
        : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryResult>
    {
        public async Task<GetProductsByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsByCategoryQueryHandler.Handle called with {@Query}", query);
            var products = await session.Query<Product>()
                .ToListAsync(token: cancellationToken);
            var filteredProducts = new List<Product>();

            foreach (var product in products)
            {
                var categories = product.Categories.Select(c => c.ToLower());
                if (categories.Contains(query.Category.ToLower()))
                {
                    filteredProducts.Add(product);
                }
            }

            return new GetProductsByCategoryResult(filteredProducts);
        }
    }
}
