
using DotnetShop.Catalog.API.Features.Products.GetProductById;
using DotnetShop.Catalog.API.Features.Products.GetProducts;
using DotnetShop.Catalog.API.Features.Products.GetProductsByCategory;

namespace DotnetShop.Catalog.API
{
    public class AddHostUrlToImageUrlsBehavior<TRequest, TResponse>(IConfiguration configuration) : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            if (response is GetProductsResult)
            {
                foreach (var product in (response as GetProductsResult).Products)
                {
                    AddHostUrlToImageUrls(product);
                }
            }

            if (response is GetProductsByCategoryResult)
            {
                foreach (var product in (response as GetProductsByCategoryResult).Products)
                {
                    AddHostUrlToImageUrls(product);
                }
            }

            if (response is GetProductByIdResult)
            {
                AddHostUrlToImageUrls((response as GetProductByIdResult).Product);
            }

            return response;
        }

        private void AddHostUrlToImageUrls(Product product)
        {
            List<string> imageUrls = [];

            product.ImageThumbnailUrl = configuration["HostUrl"] + product.ImageThumbnailUrl;
            product.ImageUrls = product.ImageUrls.Select(i => configuration["HostUrl"] + i).ToList();
        }
    }
}
