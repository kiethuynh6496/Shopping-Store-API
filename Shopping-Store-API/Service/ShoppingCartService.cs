using Microsoft.AspNetCore.Http;
using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using Shopping_Store_API.Service.Parameters;
using Shopping_Store_API.Users;

namespace Shopping_Store_API.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ShoppingCartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ShoppingCart> GetShoppingCart(string userId, bool IsTracked)
        {
            var getShoppingCart = await _unitOfWork.ShoppingCart.GetShoppingCart(userId, IsTracked);

            return getShoppingCart;
        }

        public async Task<bool> AddItemToShoppingCart(string userId, ShoppingCartParameters shoppingCartParameters, HttpResponse httpResponse)
        {
            // Get Shopping Cart
            var shoppingCart = await _unitOfWork.ShoppingCart.GetShoppingCart(userId, true);
            if (shoppingCart == null)
            {
                shoppingCart = _unitOfWork.ShoppingCart.CreateShoppingCart(userId, httpResponse);

                // Add Shopping Cart
                var createShoppingCartResult = await _unitOfWork.ShoppingCart.Add(shoppingCart);
                if (createShoppingCartResult == false)
                {
                    throw new ApiError((int)ErrorCodes.ShoppingCartCantBeCreated);
                }
            }

            // Get Product
            var product = await _unitOfWork.Products.GetById(p => p.Id == shoppingCartParameters.productId);
            if (product == null)
            {
                throw new ApiError((int)ErrorCodes.ProductDataDoesntExist);
            }

            // Add Item to ShoppingCartItem
            shoppingCart.AddItem(product, shoppingCartParameters.quantity);

            UpdateEntity(shoppingCart, shoppingCartParameters);

            // Updata Db in 2 tables: ShoppingCartItem and ShoppingCart
            var result = await _unitOfWork.CommitAsync();
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RemoveItemToShoppingCart(string userId, ShoppingCartParameters shoppingCartParameters)
        {
            // Get Shopping Cart
            var shoppingCart = await _unitOfWork.ShoppingCart.GetShoppingCart(userId, true);
            if (shoppingCart == null)
            {
                throw new ApiError((int)ErrorCodes.ShoppingCartDoesntExist);
            }

            // Remove product in Cart
            shoppingCart.RemoveItem(shoppingCartParameters.productId, shoppingCartParameters.quantity);

            UpdateEntity(shoppingCart, shoppingCartParameters);

            // Updata ShoppingCartItem table
            var result = await _unitOfWork.CommitAsync();
            if (result == 0)
            {
                return false;
            }
            return true;
        }

        private void UpdateEntity(ShoppingCart? shoppingCart, ShoppingCartParameters shoppingCartParameters)
        {
            // Update data in ShoppingCartItem
            var updateShoppingItemCartResult = _unitOfWork.ShoppingCartItem.Update(shoppingCart.ShoppingCartItems.FirstOrDefault(item => item.ItemId == shoppingCartParameters.productId));
            if (updateShoppingItemCartResult == false)
            {
                throw new ApiError((int)ErrorCodes.DataArentUpdatedSuccessfullyInShoppingCartItem);
            }

            // Update data int ShoppingCart
            var updateShoppingCartResult = _unitOfWork.ShoppingCart.Update(shoppingCart);
            if (updateShoppingCartResult == false)
            {
                throw new ApiError((int)ErrorCodes.ShoppingCartCantBeUpdated);
            }
        }
    }
}
