using DotnetShop.WebApp.Models.Catalog;

namespace DotnetShop.WebApp.Services
{
    public class CatalogService : HttpClientFactoryBase, ICatalogService
    {
        private readonly string CatalogBaseUri;

        protected CatalogService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            CatalogBaseUri = configuration["ServiceUri:Catalog"]!;
        }

        public async Task<IEnumerable<ProductModel>> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await GetAsync<IEnumerable<ProductModel>>("ProductClient", $"{CatalogBaseUri}/products?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ProductModel> GetProductById(int productId, CancellationToken cancellationToken)
        {
            return await GetAsync<ProductModel>("ProductClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await GetAsync<IEnumerable<ProductModel>>("ProductClient", $"{CatalogBaseUri}/products/category/{categoryName}");
        }

        public async Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await PostAsync<int>("ProductClient", $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            return await PutAsync<bool>("ProductClient", $"{CatalogBaseUri}/products", product);
        }

        public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            return await DeleteAsync<bool>("ProductClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories(CancellationToken cancellationToken)
        {
            return await GetAsync<IEnumerable<CategoryModel>>("CategoryClient", $"{CatalogBaseUri}/categories");
        }

        public async Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken)
        {
            return await PostAsync<Guid>("CategoryClient", $"{CatalogBaseUri}/categories", category);
        }
    }
}
