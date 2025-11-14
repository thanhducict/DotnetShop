using DotnetShop.WebApp.Models.Catalog;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.WebApp.Pages.Catalog
{
    public class DetailsModel(ICatalogService catalogService) : PageModel
    {
        public ProductModel Product { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            var result = await catalogService.GetProductById(id, cancellationToken);
            if (result == null)
            {
                Product = new ProductModel();
            }
            else
            {
                Product = result.Product;
            }
        }
    }
}
