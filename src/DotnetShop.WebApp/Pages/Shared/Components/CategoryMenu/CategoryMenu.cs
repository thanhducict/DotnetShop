using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.WebApp.Pages.Shared.Components.CategoryMenu
{
    public class CategoryMenu(ICatalogService catalogService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var result = await catalogService.GetCategories(cancellationToken);

            return View(result.Categories);
        }
    }
}
