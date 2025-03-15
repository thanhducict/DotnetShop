using DotnetShop.WebApp.Models.Catalog;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.WebApp.Pages.Catalog
{
    public class ListModel(ICatalogService catalogService) : PageModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
        public string CurrentCategory { get; set; }

        public void OnGet(int categoryId)
        {
            //if (categoryId > 0)
            //{
            //    Products = catalogService.GetProducts().Where(p => p.Category.CategoryId == categoryId)
            //         .OrderBy(p => p.ProductId);
            //    CurrentCategory = catalogService.GetCategories()
            //        .FirstOrDefault(c => c.CategoryId == categoryId)?.CategoryName;
            //}
            //else
            //{
            //    Products = catalogService.GetProducts().OrderBy(p => p.ProductId);
            //    CurrentCategory = "All products";
            //}
        }
    }
}
