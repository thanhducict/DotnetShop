using DotnetShop.WebApp.Models.Catalog;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.WebApp.Pages.Catalog
{
    public class ListModel(ICatalogService catalogService) : PageModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public string CurrentCategory { get; set; }

        public async Task OnGet(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10)
        {
            var result = await catalogService.GetProducts(pageNumber, pageSize, cancellationToken);

            Products = result.ToList();
        }
    }
}
