using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name = "Product")]
    public class ProductComponent : ViewComponent
    {
        private readonly DataContext _context;
        public ProductComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofProduct = (from p in _context.Products
                                 where (p.IsActive == true) && (p.Status == 1)
								 orderby p.ProductID descending
								 select p).Take(5).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofProduct));
        }
    }
}
