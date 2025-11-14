using DotnetShop.Admin.Core.HttpClient;
using DotnetShop.Admin.UI.Dtos;
using DotnetShop.Admin.UI.Models;

namespace DotnetShop.Admin.UI.Services
{
    public class CatalogService(IHttpClientFactoryBase httpClientFactoryBase, IConfiguration configuration)
        : ICatalogService
    {
        private readonly string CatalogBaseUri = configuration["ServiceUri:Catalog"]!;

        public async Task<GetProductsDto> GetProducts(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = Constants.PageSize)
        {
            return await httpClientFactoryBase.GetAsync<GetProductsDto>(Constants.CatalogClient, $"{CatalogBaseUri}/products?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<GetProductByIdDto> GetProductById(int productId, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductByIdDto>(Constants.CatalogClient, $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<GetProductsByCategoryDto> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductsByCategoryDto>(Constants.CatalogClient, $"{CatalogBaseUri}/products/category/{categoryName}");
        }

        public async Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PostAsync<int>(Constants.CatalogClient, $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PutAsync<bool>(Constants.CatalogClient, $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.DeleteAsync<bool>(Constants.CatalogClient, $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<GetCategoriesDto> GetCategories(CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetCategoriesDto>(Constants.CatalogClient, $"{CatalogBaseUri}/categories");
        }

        public async Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PostAsync<Guid>(Constants.CatalogClient, $"{CatalogBaseUri}/categories", category);
        }
    }
}
