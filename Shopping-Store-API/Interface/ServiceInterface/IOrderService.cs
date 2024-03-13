using Shopping_Store_API.DTOs.OrderDTOs;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders(string userEmail);
        Task<IEnumerable<Order>> GetOrderById(int id, string userEmail);
        Task<bool> CreateOrder(string userId, OrderRequestDTO orderRequestDTO);
    }
}
