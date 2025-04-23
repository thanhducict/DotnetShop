using DotnetShop.Admin.UI.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Admin.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CatalogController(ICatalogService catalogService) : Controller
    {
        public async Task<IActionResult> Index(int PageNumber = 1, int PageSize = 10)
        {
            var result = await catalogService.GetProducts(CancellationToken.None, PageNumber, PageSize);
            
            return View(result);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await catalogService.GetProductById(id, CancellationToken.None);

            return View(result.Product);
        }
    }
}
