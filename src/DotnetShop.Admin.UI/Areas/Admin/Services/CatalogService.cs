using DotnetShop.Admin.Core.HttpClient;
using DotnetShop.Admin.UI.Areas.Admin.Dtos;
using DotnetShop.Admin.UI.Areas.Admin.Models;

namespace DotnetShop.Admin.UI.Areas.Admin.Services
{
    public class CatalogService(IHttpClientFactoryBase httpClientFactoryBase, IConfiguration configuration)
        : ICatalogService
    {
        private readonly string CatalogBaseUri = configuration["ServiceUri:Catalog"]!;

        public async Task<GetProductsDto> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductsDto>("CatalogClient", $"{CatalogBaseUri}/products?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<GetProductByIdDto> GetProductById(int productId, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductByIdDto>("CatalogClient", $"{CatalogBaseUri}/products/{productId}");
        }

        public async Task<GetProductsByCategoryDto> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetProductsByCategoryDto>("CatalogClient", $"{CatalogBaseUri}/products/category/{categoryName}");
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

        public async Task<GetCategoriesDto> GetCategories(CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.GetAsync<GetCategoriesDto>("CatalogClient", $"{CatalogBaseUri}/categories");
        }

        public async Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken)
        {
            return await httpClientFactoryBase.PostAsync<Guid>("CatalogClient", $"{CatalogBaseUri}/categories", category);
        }
    }
}
