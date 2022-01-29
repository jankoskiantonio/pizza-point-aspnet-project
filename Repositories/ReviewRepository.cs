using PizzaPointProject.Models;
using Microsoft.EntityFrameworkCore;
using PizzaPointProject.Data;

namespace PizzaPointProject.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reviews> Reviews => _context.Reviews.Include(x => x.Pizza); //include here

        public void Add(Reviews review)
        {
            _context.Reviews.Add(review);
        }

        public IEnumerable<Reviews> GetAll()
        {
            return _context.Reviews.ToList();
        }

        public async Task<IEnumerable<Reviews>> GetAllAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public Reviews GetById(int? id)
        {
            return _context.Reviews.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Reviews> GetByIdAsync(int? id)
        {
            return await _context.Reviews.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Reviews.Any(p => p.Id == id);
        }

        public void Remove(Reviews review)
        {
            _context.Reviews.Remove(review);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Reviews review)
        {
            _context.Reviews.Update(review);
        }
    }
}
