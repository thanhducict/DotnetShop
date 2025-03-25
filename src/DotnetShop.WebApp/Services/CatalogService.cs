using DotnetShop.WebApp.Models.Catalog;

namespace DotnetShop.WebApp.Services
{
    public class CatalogService : ICatalogService
    {
        public Task<IEnumerable<ProductModel>> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductById(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<ProductModel>> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
