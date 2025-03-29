using DotnetShop.WebApp.Models.Catalog;

namespace DotnetShop.WebApp.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<ProductModel>> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<ProductModel> GetProductById(int productId, CancellationToken cancellationToken);
        Task<IEnumerable<ProductModel>> GetProductsByCategory(string categoryName, CancellationToken cancellationToken);
        Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken);
        Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken);

        Task<IEnumerable<CategoryModel>> GetCategories(CancellationToken cancellationToken);
        Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken);
    }
}
