using DotnetShop.WebApp.Models.Catalog;

namespace DotnetShop.WebApp.Services
{
    public class CatalogService : ICatalogService
    {

        public async Task<GetProductsResponse> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            throw new Exception("Not implemented");
        }

        public async Task<GetProductByIdResponse> GetProductById(int productId, CancellationToken cancellationToken)
        {
            throw new Exception("Not implemented");
        }

        public async Task<GetProductsByCategoryResponse> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            throw new Exception("Not implemented");
        }

        public async Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            throw new Exception("Not implemented");
        }

        public async Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            throw new Exception("Not implemented");
        }

        public async Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            throw new Exception("Not implemented");
        }

        public async Task<GetCategoriesResponse> GetCategories(CancellationToken cancellationToken)
        {
            throw new Exception("Not implemented");
        }

        public async Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken)
        {
            throw new Exception("Not implemented");
        }
    }
}
