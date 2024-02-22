using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs.OrderDTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;

namespace Shopping_Store_API.Service
{
    public class OrderService : IOrderService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> GetOrderById(int id, string userId)
        {
            var ordersById = await _unitOfWork.Order.GetOrderById(id, userId).ToListAsync();
            if (ordersById == null) throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            return ordersById;
        }

        public async Task<IEnumerable<Order>> GetOrders(string userId)
        {
            var ordersList = await _unitOfWork.Order.GetOrders(userId).ToListAsync();
            if (ordersList == null) throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            return ordersList;
        }

        public async Task<bool> CreateOrder(string userId, OrderRequestDTO orderRequestDTO)
        {
            // Handle User
            var currentUser = await _userManager.FindByIdAsync(userId);
            currentUser.FullName = orderRequestDTO.FullName;
            await _userManager.UpdateAsync(currentUser);

            // Handle Shopping Cart
            var shoppingCart = await _unitOfWork.ShoppingCart.GetShoppingCart(userId, true);

            if (shoppingCart == null) throw new ApiError((int)ErrorCodes.ShoppingCartDoesntExist);

            var items = new List<OrderItem>();

            foreach (var item in shoppingCart.ShoppingCartItems)
            {
                var productItem = await _unitOfWork.Products.FindById(i => i.Id.Equals(item.ItemId), true);

                var orderItem = new OrderItem
                {
                    ItemId = item.ItemId,
                    Item = item.Item,
                    Quantity = item.Quantity,
                };
                items.Add(orderItem);
                productItem.QuantityInStock -= item.Quantity;
            }

            var total = items.Sum(item => item.Item.Price * item.Quantity);

            var order = new Order
            {
                UserId = userId,
                OrderItems = items,
                PaymentIntenId = shoppingCart.PaymentIntenId,
                Total = total,
                MomoRequestId = Guid.NewGuid().ToString()
            };

            // Handle Address
            var address = await _unitOfWork.Address.FindById(a => a.UserId.Equals(userId));
            if (address != null)
            {
                if (address.AddressName.Equals(orderRequestDTO.AddressName) && orderRequestDTO.isDefault == true)
                {
                    address.isDefault = true;
                }
            }
            var newAddress = new Address
            {
                UserId = userId,
                AddressName = orderRequestDTO.AddressName,
                City = orderRequestDTO.City,
                isDefault = orderRequestDTO.isDefault,
            };
            var addAddress = await _unitOfWork.Address.Add(newAddress);
            if (!addAddress) throw new ApiError((int)ErrorCodes.AddressIsntAddedSuccessfully);

            // Handle Order
            var addOrder = await _unitOfWork.Order.Add(order);
            if (!addOrder) throw new ApiError((int)ErrorCodes.OrderIsntAddedSuccessfully);

            //Remove Shopping Cart
            var removeCart = _unitOfWork.ShoppingCart.Delete(shoppingCart);
            if (!removeCart) throw new ApiError((int)ErrorCodes.ShoppingCartCantBeRemoved);

            // Commit all
            var save = await _unitOfWork.CommitAsync();
            if (save <= 0)
            {
                throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);
            }
            return true;
        }
    }
}
