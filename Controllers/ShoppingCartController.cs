using Microsoft.AspNetCore.Mvc;
using PizzaPointProject.Repositories;
using PizzaPointProject.Models;
using PizzaPointProject.ViewModels;
using PizzaPointProject.Data;

namespace OnlinePizzaWebApplication.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPizzaRepository _pizzaRepository;
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;
        
        public ShoppingCartController(IPizzaRepository pizzaRepository,
            ShoppingCart shoppingCart, ApplicationDbContext context)
        {
            _pizzaRepository = pizzaRepository;
            _shoppingCart = shoppingCart;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public async Task<IActionResult> AddToShoppingCart(int pizzaId)
        {
            var selectedPizza = await _pizzaRepository.GetByIdAsync(pizzaId);

            if (selectedPizza != null)
            {
                await _shoppingCart.AddToCartAsync(selectedPizza, 1);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromShoppingCart(int pizzaId)
        {
            var selectedPizza = await _pizzaRepository.GetByIdAsync(pizzaId);

            if (selectedPizza != null)
            {
                await _shoppingCart.RemoveFromCartAsync(selectedPizza);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearCart()
        {
            await _shoppingCart.ClearCartAsync();

            return RedirectToAction("Index");
        }

    }
}