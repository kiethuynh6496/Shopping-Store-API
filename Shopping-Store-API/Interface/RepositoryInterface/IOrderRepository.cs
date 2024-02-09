using Shopping_Store_API.DTOs;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Interface.RepositoryInterface
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IQueryable<Order> GetOrders(string userId);
        IQueryable<Order> GetOrderById(int id, string userId);
    }
}
