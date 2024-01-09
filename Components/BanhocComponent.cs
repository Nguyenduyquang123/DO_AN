using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name = "Banhoc")]
    public class BanhocComponent : ViewComponent
    {
        private readonly DataContext _context;
        public BanhocComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listoBanhoc = (from p in _context.Products
                                 where (p.IsActive == true) && (p.MenuID == 4)
                                 orderby p.ProductID descending
                                 select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listoBanhoc));
        }
    }
}
