using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Admin.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
