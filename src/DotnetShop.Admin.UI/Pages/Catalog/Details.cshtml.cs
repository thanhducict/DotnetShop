using DotnetShop.Admin.UI.Models;
using DotnetShop.Admin.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.Admin.UI.Pages.Catalog
{
    public class DetailsModel(ICatalogService catalogService) : PageModel
    {
        public ProductModel Product { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            var result = await catalogService.GetProductById(id, CancellationToken.None);

            if (result == null)
            {
                RedirectToPage("/Catalog/List");
                return;
            }

            Product = result.Product;
        }
    }
}
