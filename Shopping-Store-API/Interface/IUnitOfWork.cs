﻿using Shopping_Store_API.Interface.RepositoryInterface;

namespace Shopping_Store_API.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }

        IShoppingCartRepository ShoppingCart { get; }

        IShoppingCartItemRepository ShoppingCartItem { get; }

        ITokenRepository Token { get; }

        IOrderRepository Order { get; }

        IAddressRepository Address { get; }

        IBrandRepository Brand { get; }

        ICategoryRepository Category { get; }

        Task<int> CommitAsync();
    }
}
