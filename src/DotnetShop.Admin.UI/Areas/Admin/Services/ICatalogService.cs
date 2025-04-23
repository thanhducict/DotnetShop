using DotnetShop.Admin.UI.Areas.Admin.Dtos;
using DotnetShop.Admin.UI.Areas.Admin.Models;

namespace DotnetShop.Admin.UI.Areas.Admin.Services
{
    public interface ICatalogService
    {
        Task<GetProductsDto> GetProducts(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10);
        Task<GetProductByIdDto> GetProductById(int productId, CancellationToken cancellationToken);
        Task<GetProductsByCategoryDto> GetProductsByCategory(string categoryName, CancellationToken cancellationToken);
        Task<int> CreateProduct(ProductModel product, CancellationToken cancellationToken);
        Task<bool> UpdateProduct(ProductModel product, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(int productId, CancellationToken cancellationToken);

        Task<GetCategoriesDto> GetCategories(CancellationToken cancellationToken);
        Task<Guid> CreateCategory(CategoryModel category, CancellationToken cancellationToken);
    }
}
