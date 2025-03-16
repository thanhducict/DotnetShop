using DotnetShop.WebApp.Models.Catalog;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.WebApp.Pages.Catalog
{
    public class DetailsModel : PageModel
    {
        private readonly ICatalogService _catalogService;

        public ProductModel Product { get; set; }

        public DetailsModel(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        public void OnGet(Guid guid)
        {
            //var result = _catalogService.GetProductByGuid(id);
            //if (result == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    Product = result;
            //}
        }
    }
}
