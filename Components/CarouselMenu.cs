using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaPointProject.Data;

namespace PizzaPointProject.Components
{
    public class CarouselMenu : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public CarouselMenu(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pizzas = await _context.Pizzas.Where(x => x.IsPizzaOfTheWeek).ToListAsync();
            return View(pizzas);
        }
    }
}
