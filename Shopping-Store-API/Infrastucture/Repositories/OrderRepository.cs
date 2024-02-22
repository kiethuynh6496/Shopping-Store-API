using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface.RepositoryInterface;
using Shopping_Store_API.Repositories;
using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.Infrastucture.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<Order> GetOrders(string userId)
        {
            var getAllOrders = FindByCondition(o => o.UserId.Equals(userId))
                                .Include(o => o.OrderItems)
                                .ThenInclude(p => p.Item);
            return getAllOrders;
        }

        public IQueryable<Order> GetOrderByStatus(OrderStatus orderStatus, string userId)
        {
            var getAllOrders = FindByCondition(o => o.UserId.Equals(userId) && o.OrderStatus == orderStatus)
                                .Include(o => o.OrderItems)
                                .ThenInclude(p => p.Item);
            return getAllOrders;
        }

        public IQueryable<Order> GetOrderById(int id, string userId)
        {
            var getOrderById = FindByCondition(o => o.Id.Equals(id) && o.UserId.Equals(userId))
                                .Include(o => o.OrderItems)
                                .ThenInclude(p => p.Item);
            return getOrderById;
        }
    }
}
