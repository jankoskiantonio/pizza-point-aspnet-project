using PizzaPointProject.Models;

namespace PizzaPointProject.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);

    }
}
