namespace DotnetShop.Catalog.API.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts(int pageNumber, int pageSize);
        Task<Product> GetProductById(int productId);
        Task<Product> GetProductByCategory(string categoryName);
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
