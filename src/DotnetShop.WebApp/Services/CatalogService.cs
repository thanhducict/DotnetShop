using DotnetShop.WebApp.Models.Catalog;

namespace DotnetShop.WebApp.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly string CatalogBaseUri;
        private readonly IHttpClientFactoryBase _httpClientFactoryBase;

        public CatalogService(IHttpClientFactoryBase httpClientFactoryBase, IConfiguration configuration)
        {
            CatalogBaseUri = configuration["ServiceUri:Catalog"]!;
            _httpClientFactoryBase = httpClientFactoryBase;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await _httpClientFactoryBase.GetAsync<IEnumerable<ProductModel>>("ProductClient", $"{CatalogBaseUri}/products?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ProductModel> GetProductById(int productId, CancellationToken cancellationToken)
        {
            return await _httpClientFactoryBase.GetAsync<ProductModel>("ProductClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await _httpClientFactoryBase.GetAsync<IEnumerable<ProductModel>>("ProductClient", $"{CatalogBaseUri}/products/category/{categoryName}");
        }

        public async Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await _httpClientFactoryBase.PostAsync<int>("ProductClient", $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await _httpClientFactoryBase.PutAsync<bool>("ProductClient", $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            return await _httpClientFactoryBase.DeleteAsync<bool>("ProductClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories(CancellationToken cancellationToken)
        {
            return await _httpClientFactoryBase.GetAsync<IEnumerable<CategoryModel>>("CategoryClient", $"{CatalogBaseUri}/categories");
        }

        public async Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken)
        {
            return await _httpClientFactoryBase.PostAsync<Guid>("CategoryClient", $"{CatalogBaseUri}/categories", category);
        }
    }
}
