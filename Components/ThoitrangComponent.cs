using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name = "Thoitrang")]
    public class ThoitrangComponent : ViewComponent
    {
        private readonly DataContext _context;
        public ThoitrangComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofThoitrang = (from p in _context.Products
                                  where (p.IsActive == true) && (p.MenuID == 6)
                                  orderby p.ProductID descending
                                  select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofThoitrang));
        }
    }
}
