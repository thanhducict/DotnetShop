using DotnetShop.WebApp.Models.Catalog;

namespace DotnetShop.WebApp.Services
{
    public class CatalogService(IHttpClientFactoryBase httpClientFactoryBase, IConfiguration configuration) : ICatalogService
    {
        private readonly string CatalogBaseUri = configuration["ServiceUri:Catalog"]!;

        public async Task<GetProductsResponse> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductsResponse>("ProductClient", $"{CatalogBaseUri}/products?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<GetProductByIdResponse> GetProductById(int productId, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductByIdResponse>("ProductClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<GetProductsByCategoryResponse> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductsByCategoryResponse>("ProductClient", $"{CatalogBaseUri}/products/category/{categoryName}");
        }

        public async Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PostAsync<int>("ProductClient", $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PutAsync<bool>("ProductClient", $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.DeleteAsync<bool>("ProductClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<GetCategoriesResponse> GetCategories(CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetCategoriesResponse>("CategoryClient", $"{CatalogBaseUri}/categories");
        }

        public async Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PostAsync<Guid>("CategoryClient", $"{CatalogBaseUri}/categories", category);
        }
    }
}
