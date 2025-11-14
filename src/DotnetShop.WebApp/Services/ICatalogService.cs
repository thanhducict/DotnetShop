using DotnetShop.WebApp.Models.Catalog;

namespace DotnetShop.WebApp.Services
{
    public interface ICatalogService
    {
        Task<GetProductsResponse> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<GetProductByIdResponse> GetProductById(int productId, CancellationToken cancellationToken);
        Task<GetProductsByCategoryResponse> GetProductsByCategory(string categoryName, CancellationToken cancellationToken);

        Task<GetCategoriesResponse> GetCategories(CancellationToken cancellationToken);
    }
}
