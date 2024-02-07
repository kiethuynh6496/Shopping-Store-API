using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;

namespace Shopping_Store_API.Service
{
    public class OrderService : IOrderService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(UserManager<AppUser> userManager, IConfiguration config, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _config = config;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> GetOrderById(int id, string userEmail)
        {
            var ordersById = await _unitOfWork.Order.GetOrderById(id, userEmail).ToListAsync();
            if (ordersById == null)
            {
                throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            }
            return ordersById;
        }

        public async Task<IEnumerable<Order>> GetOrders(string userEmail)
        {
            var ordersList = await _unitOfWork.Order.GetOrders(userEmail).ToListAsync();
            if (ordersList == null)
            {
                throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            }
            return ordersList;
        }
    }
}
