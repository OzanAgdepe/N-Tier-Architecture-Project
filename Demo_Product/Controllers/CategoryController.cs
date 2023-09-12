using Microsoft.AspNetCore.Mvc;

namespace Demo_Product_UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
