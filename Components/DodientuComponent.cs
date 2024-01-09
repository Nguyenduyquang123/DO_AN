using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name = "Dodientu")]
    public class DodientuComponent :ViewComponent
    {
        private readonly DataContext _context;
        public DodientuComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofDodientu = (from p in _context.Products
                                   where (p.IsActive == true) && (p.MenuID == 8)
                                   orderby p.ProductID descending
                                   select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofDodientu));
        }
    }
}
