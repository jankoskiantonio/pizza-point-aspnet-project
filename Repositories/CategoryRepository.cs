using PizzaPointProject.Models;
using Microsoft.EntityFrameworkCore;
using PizzaPointProject.Data;

namespace PizzaPointProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categories> Categories => _context.Categories.Include(x => x.Pizzas); //include here

        public void Add(Categories category)
        {
            _context.Add(category);
        }

        public IEnumerable<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public Categories GetById(int? id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Categories> GetByIdAsync(int? id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Pizzas.Any(p => p.Id == id);
        }

        public void Remove(Categories category)
        {
            _context.Remove(category);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Categories category)
        {
            _context.Update(category);
        }

    }
}
