using DotnetShop.WebApp.Models.Catalog;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.WebApp.Pages.Shared.CategoryMenu
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICatalogService _catalogService;

        public CategoryMenu(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = new List<CategoryModel>();
            return View(categories);
        }
    }
}
