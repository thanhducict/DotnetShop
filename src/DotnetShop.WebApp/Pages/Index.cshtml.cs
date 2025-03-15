using DotnetShop.WebApp.Models.Catalog;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public string Slogan { get; set; } = string.Empty;

        public IEnumerable<ProductModel> ProductsOfTheWeek { get; set; } = [];

        public void OnGet()
        {
            ProductsOfTheWeek = ProductsOfTheWeek.TakeRandom(5);
                //_productRepository.GetProducts().Where(p => p.IsProductOfTheWeek);
        }

        public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                  PageHandlerExecutionDelegate next)
        {
            Slogan = "Our weekly selection - just for you!";
            await next.Invoke();
        }
    }
}
