using Microsoft.AspNetCore.Mvc;
using DO_AN_PTUD.Models;

namespace DO_AN_PTUD.Components
{
    [ViewComponent(Name  = "RencentPost")]
    public class RecentPostComponent : ViewComponent
    {
        private readonly DataContext _context;
        public RecentPostComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost =(from p in _context.Posts
                             where (p.IsActive == true) && ( p.Status == 1)
                             orderby p.PostID descending
                             select p).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
