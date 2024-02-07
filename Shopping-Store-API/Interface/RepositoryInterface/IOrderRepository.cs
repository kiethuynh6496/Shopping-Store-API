using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Interface.RepositoryInterface
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IQueryable<Order> GetOrders(string userEmail);
        IQueryable<Order> GetOrderById(int id, string userEmail);
    }
}
