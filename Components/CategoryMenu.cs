using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPointProject.Data;

namespace PizzaPointProject.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public CategoryMenu(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            return View(categories);
        }
    }
}
