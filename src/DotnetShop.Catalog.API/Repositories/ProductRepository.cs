
namespace DotnetShop.Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
