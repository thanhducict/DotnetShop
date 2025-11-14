using Microsoft.AspNetCore.Mvc;

namespace DotnetShop.Admin.Ordering.Areas.Admin.Controllers
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
