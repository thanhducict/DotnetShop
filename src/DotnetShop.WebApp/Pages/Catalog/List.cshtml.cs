using DotnetShop.WebApp.Models.Catalog;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.WebApp.Pages.Catalog
{
    public class ListModel(ICatalogService catalogService) : PageModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public string CurrentCategory { get; set; }

        public async Task OnGet(CancellationToken cancellationToken, string categoryName = "", int pageNumber = 1, int pageSize = 10)
        {
            return;
            if (string.IsNullOrEmpty(categoryName))
            {
                var productsResponse = await catalogService.GetProducts(pageNumber, pageSize, cancellationToken);
                Products = productsResponse.Products;
            }
            else
            {
                var productsByCategoryResponse = await catalogService.GetProductsByCategory(categoryName, cancellationToken);
                CurrentCategory = categoryName;
                Products = productsByCategoryResponse.Products;
            }
        }
    }
}
