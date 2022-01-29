using PizzaPointProject.Models;

namespace PizzaPointProject.Repositories
{
    public interface IReviewRepository
    {
        IEnumerable<Reviews> Reviews { get; }

        Reviews GetById(int? id);
        Task<Reviews> GetByIdAsync(int? id);

        bool Exists(int id);

        IEnumerable<Reviews> GetAll();
        Task<IEnumerable<Reviews>> GetAllAsync();

        void Add(Reviews review);
        void Update(Reviews review);
        void Remove(Reviews review);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
