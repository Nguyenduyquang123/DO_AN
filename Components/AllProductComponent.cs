using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name = "AllProduct")]
    public class AllProductComponent : ViewComponent
    {
        private readonly DataContext _context;
        public AllProductComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofAllProduct = (from p in _context.Products
                                 where (p.IsActive == true) && (p.MenuID == 1)
									orderby p.ProductID descending
									select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofAllProduct));
        }
    }
}
