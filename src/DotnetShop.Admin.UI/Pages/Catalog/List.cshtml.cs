using DotnetShop.Admin.UI.Models;
using DotnetShop.Admin.UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.Admin.UI.Pages.Catalog
{
    [Authorize(Roles = "Admin")]
    public class ListModel(ICatalogService catalogService) : PageModel
    {
        public IEnumerable<ProductModel> Products { get; set; } = default!;
        public PagingInfoModel PagingInfo { get; set; } = default!;

        public async Task OnGet(CancellationToken cancellationToken, int PageNumber = 1, int PageSize = 10)
        {
            var result = await catalogService.GetProducts(cancellationToken, PageNumber, PageSize);

            Products = result.Products;
            PagingInfo = result.PagingInfo;
        }
    }
}
