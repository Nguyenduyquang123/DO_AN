using DO_AN_PTUD.Models;
using DO_AN_PTUD.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DO_AN_PTUD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login"); 

            var mnList = _context.Products.OrderBy(m => m.ProductID).ToList();
            return View(mnList);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Products.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var deleProduct = _context.Products.Find(id);
            if (deleProduct == null)
            {
                return NotFound();
            }
            _context.Products.Remove(deleProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            var mnList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product mn)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }

        public IActionResult Edit(long? id)
        {
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var mn = _context.Products.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			var mnList = (from m in _context.Menus
						  select new SelectListItem()
						  {
							  Text = m.MenuName,
							  Value = m.MenuID.ToString(),
						  }).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "---Select---",
				Value = string.Empty
			});
			ViewBag.mnList = mnList;
			return View(mn);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Product mn)
        {
			if (ModelState.IsValid)
			{
				_context.Products.Update(mn);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(mn);
		}
    }
}
