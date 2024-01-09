using DO_AN_PTUD.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/file-manager")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
      
    }
}
