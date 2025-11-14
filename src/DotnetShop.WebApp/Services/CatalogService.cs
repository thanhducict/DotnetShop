using DotnetShop.WebApp.Models.Catalog;

namespace DotnetShop.WebApp.Services
{
    public class CatalogService(HttpClient httpClient) : ICatalogService
    {
        public async Task<GetProductsResponse> GetProducts(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await httpClient.GetFromJsonAsync<GetProductsResponse>($"products?pageNumber={pageNumber}&pageSize={pageSize}", cancellationToken)
                ?? new GetProductsResponse([]);
        }

        public async Task<GetProductByIdResponse> GetProductById(int productId, CancellationToken cancellationToken)
        {
            return await httpClient.GetFromJsonAsync<GetProductByIdResponse>($"products/{productId}", cancellationToken)
                ?? new GetProductByIdResponse(new ProductModel());
        }

        public async Task<GetProductsByCategoryResponse> GetProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await httpClient.GetFromJsonAsync<GetProductsByCategoryResponse>($"products/category/{categoryName}", cancellationToken)
                ?? new GetProductsByCategoryResponse([]);
        }

        public async Task<GetCategoriesResponse> GetCategories(CancellationToken cancellationToken)
        {
            return await httpClient.GetFromJsonAsync<GetCategoriesResponse>("categories", cancellationToken)
                ?? new GetCategoriesResponse([]);
        }
    }
}
