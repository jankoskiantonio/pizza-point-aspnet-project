using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PizzaPointProject.Repositories;
using PizzaPointProject.Data;

namespace PizzaPointProject.Controllers
{
    //Require Admin role
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdminRepository _adminRepo;

        public AdminController(ApplicationDbContext context, IAdminRepository adminRepo)
        {
            _context = context;
            _adminRepo = adminRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Drop Database
        public IActionResult ClearDatabaseAsync()
        {
            _adminRepo.ClearDatabase();
            return RedirectToAction("Index", "Pizzas", null);
        }
        //Database Seeding
        public IActionResult SeedDatabaseAsync()
        {
            _adminRepo.ClearDatabase();
            _adminRepo.SeedDatabase();
            return RedirectToAction("Index", "Pizzas", null);
        }

    }
}