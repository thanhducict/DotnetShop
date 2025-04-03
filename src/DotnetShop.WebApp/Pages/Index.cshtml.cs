using DotnetShop.WebApp.Models.Catalog;
using DotnetShop.WebApp.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetShop.WebApp.Pages
{
    public class IndexModel(ICatalogService catalogService) : PageModel
    {
        public string Slogan { get; set; } = string.Empty;

        public IEnumerable<ProductModel> ProductsOfTheWeek { get; set; } = [];

        public async Task OnGetAsync(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 10)
        {
            var result = await catalogService.GetProducts(pageNumber, pageSize, cancellationToken);

            ProductsOfTheWeek = result.TakeRandom(5);
        }

        public override async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                  PageHandlerExecutionDelegate next)
        {
            Slogan = "Our weekly selection - just for you!";
            await next.Invoke();
        }
    }
}
