using PizzaPointProject.Data;
using PizzaPointProject.Models;

namespace PizzaPointProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;


        public OrderRepository(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            decimal totalPrice = 0M;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    PizzaId = shoppingCartItem.Pizza.Id,
                    Order = order,
                    Price = shoppingCartItem.Pizza.Price,
                    
                };
                totalPrice += orderDetail.Price * orderDetail.Amount;
                _context.OrderDetails.Add(orderDetail);
            }

            order.OrderTotal = totalPrice;
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
        }
    }
}
