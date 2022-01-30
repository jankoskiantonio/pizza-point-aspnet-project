using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaPointProject.Models;
using Microsoft.AspNetCore.Authorization;
using PizzaPointProject.Data;

namespace PizzaPointProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PizzaIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PizzaIngredientsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PizzaIngredients
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PizzaIngredients.Include(p => p.Ingredient).Include(p => p.Pizza);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PizzaIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaIngredients = await _context.PizzaIngredients
                .Include(p => p.Ingredient)
                .Include(p => p.Pizza)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pizzaIngredients == null)
            {
                return NotFound();
            }

            return View(pizzaIngredients);
        }

        // GET: PizzaIngredients/Create
        public IActionResult Create()
        {
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Name");
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name");
            return View();
        }

        // POST: PizzaIngredients/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PizzaId,IngredientId")] PizzaIngredients pizzaIngredients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizzaIngredients);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Name", pizzaIngredients.IngredientId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", pizzaIngredients.PizzaId);
            return View(pizzaIngredients);
        }

        // GET: PizzaIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaIngredients = await _context.PizzaIngredients.SingleOrDefaultAsync(m => m.Id == id);
            if (pizzaIngredients == null)
            {
                return NotFound();
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Name", pizzaIngredients.IngredientId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", pizzaIngredients.PizzaId);
            return View(pizzaIngredients);
        }

        // POST: PizzaIngredients/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PizzaId,IngredientId")] PizzaIngredients pizzaIngredients)
        {
            if (id != pizzaIngredients.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizzaIngredients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaIngredientsExists(pizzaIngredients.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Name", pizzaIngredients.IngredientId);
            ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name", pizzaIngredients.PizzaId);
            return View(pizzaIngredients);
        }

        // GET: PizzaIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaIngredients = await _context.PizzaIngredients
                .Include(p => p.Ingredient)
                .Include(p => p.Pizza)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (pizzaIngredients == null)
            {
                return NotFound();
            }

            return View(pizzaIngredients);
        }

        // POST: PizzaIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizzaIngredients = await _context.PizzaIngredients.SingleOrDefaultAsync(m => m.Id == id);
            _context.PizzaIngredients.Remove(pizzaIngredients);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PizzaIngredientsExists(int id)
        {
            return _context.PizzaIngredients.Any(e => e.Id == id);
        }
    }
}
