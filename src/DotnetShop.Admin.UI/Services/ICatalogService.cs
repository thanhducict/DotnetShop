using DotnetShop.Admin.UI.Models;

namespace DotnetShop.Admin.UI.Services
{
    public interface ICatalogService
    {
        Task<GetProductsResponse> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<GetProductByIdResponse> GetProductById(int productId, CancellationToken cancellationToken);
        Task<GetProductsByCategoryResponse> GetProductsByCategory(string categoryName, CancellationToken cancellationToken);
        Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken);
        Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken);

        Task<GetCategoriesResponse> GetCategories(CancellationToken cancellationToken);
        Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken);
    }
}
