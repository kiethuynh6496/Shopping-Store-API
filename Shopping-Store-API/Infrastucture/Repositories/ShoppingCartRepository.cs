﻿using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface.RepositoryInterface;
using Shopping_Store_API.Repositories;

namespace Shopping_Store_API.Infrastucture.Repositories
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        public ShoppingCartRepository(DbFactory dbFactory) : base(dbFactory)
        {
            
        }

        public async Task<ShoppingCart> GetShoppingCart(string userId, bool IsTracked)
        {
            var shoppingCart = await RetrieveShoppingCart(userId, IsTracked);

            if(shoppingCart != null)
            {
                shoppingCart.ShoppingCartItems = shoppingCart.ShoppingCartItems.Where(i => i.Quantity > 0).ToList();
            }

            return shoppingCart;
        }

        public ShoppingCart CreateShoppingCart(string userId, HttpResponse httpResponse)
        {
            if (string.IsNullOrEmpty(userId)) throw new ApiError((int)ErrorCodes.SignUpPlease);
            var buyerId = userId;
            Helpers.SaveDataToCookie(buyerId, httpResponse);
            var shoppingCart = new ShoppingCart { UserId = buyerId };
            return shoppingCart;
        }

        private async Task<ShoppingCart?> RetrieveShoppingCart(string userId, bool IsTracked)
        {
            return IsTracked ? await DbSet
                                    .Include(i => i.ShoppingCartItems)
                                        .ThenInclude(p => p.Item)
                                        .ThenInclude(item => item.Category)
                                    .Include(i => i.ShoppingCartItems)
                                        .ThenInclude(p => p.Item.Brand)
                                    .FirstOrDefaultAsync(x => x.UserId == userId) :
                               await DbSet
                                    .AsNoTracking()
                                    .Include(i => i.ShoppingCartItems)
                                        .ThenInclude(p => p.Item)
                                        .ThenInclude(item => item.Category)
                                    .Include(i => i.ShoppingCartItems)
                                        .ThenInclude(p => p.Item.Brand)
                                    .FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
