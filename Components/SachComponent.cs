using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name = "Sach")]
    public class SachComponent : ViewComponent
    {

        private readonly DataContext _context;
        public SachComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofSach = (from p in _context.Products
                                      where (p.IsActive == true) && (p.MenuID == 7)
                                      orderby p.ProductID descending
                                      select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofSach));
        }
    }
}
