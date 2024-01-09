using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name = "Dienlanh")]
    public class DienlanhComponents : ViewComponent
    {
        private readonly DataContext _context;
        public DienlanhComponents(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listoDienlanh = (from p in _context.Products
                                    where (p.IsActive == true) && (p.MenuID == 3)
                                    orderby p.ProductID descending
                                    select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listoDienlanh));
        }
    }
}
