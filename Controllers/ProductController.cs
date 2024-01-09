using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
