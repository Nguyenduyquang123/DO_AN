using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name = "Noithat")]
    public class NoithatComponent : ViewComponent

    {
        private readonly DataContext _context;
        public NoithatComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofNoithat = (from p in _context.Products
                                  where (p.IsActive == true) && (p.MenuID == 5)
                                  orderby p.ProductID descending
                                  select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofNoithat));
        }
    }
}
