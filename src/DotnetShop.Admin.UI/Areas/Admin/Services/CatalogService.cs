using DotnetShop.Admin.Core.HttpClient;
using DotnetShop.Admin.UI.Areas.Admin.Models;

namespace DotnetShop.Admin.UI.Areas.Admin.Services
{
    public class CatalogService(IHttpClientFactoryBase httpClientFactoryBase, IConfiguration configuration) : ICatalogService
    {
        private readonly string CatalogBaseUri = configuration["ServiceUri:Catalog"]!;

        public async Task<GetProductsResponse> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductsResponse>("CatalogClient", $"{CatalogBaseUri}/products?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<GetProductByIdResponse> GetProductById(int productId, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductByIdResponse>("CatalogClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<GetProductsByCategoryResponse> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductsByCategoryResponse>("CatalogClient", $"{CatalogBaseUri}/products/category/{categoryName}");
        }

        public async Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PostAsync<int>("CatalogClient", $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PutAsync<bool>("CatalogClient", $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.DeleteAsync<bool>("CatalogClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<GetCategoriesResponse> GetCategories(CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetCategoriesResponse>("CatalogClient", $"{CatalogBaseUri}/categories");
        }

        public async Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PostAsync<Guid>("CatalogClient", $"{CatalogBaseUri}/categories", category);
        }
    }
}
