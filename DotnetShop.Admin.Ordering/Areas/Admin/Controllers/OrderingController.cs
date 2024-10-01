using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Admin.Ordering.Areas.Catalog.Controllers
{
    [Area("Admin")]
    public class OrderingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
