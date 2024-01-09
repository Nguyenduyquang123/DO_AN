using DO_AN_PTUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace DO_AN_PTUD.Components
{
	[ViewComponent(Name = "Products")]
	public class PeoductsComponent : ViewComponent
	{
		private readonly DataContext _context;
		public PeoductsComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listofPeoducts = (from p in _context.Products
									where (p.IsActive == true) && (p.MenuID == 2)
								  orderby p.ProductID descending
								  select p).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listofPeoducts));
		}
	}
}
