using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Infrastucture.Repositories;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.RepositoryInterface;

namespace Shopping_Store_API.Infrastucture
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;
        public IProductRepository Products { get; }
        public IShoppingCartRepository ShoppingCart { get; }
        public IShoppingCartItemRepository ShoppingCartItem { get; }
        public IOrderRepository Order { get; }
        public ITokenRepository Token { get; }
        public IAddressRepository Address { get; }

        public UnitOfWork(DbFactory dbFactory, IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, IShoppingCartItemRepository shoppingCartItemRepository, IOrderRepository orderRepository,ITokenRepository tokenRepository, IAddressRepository address)
        {
            _dbFactory = dbFactory;
            Products = productRepository;
            ShoppingCart = shoppingCartRepository;
            ShoppingCartItem = shoppingCartItemRepository;
            Order = orderRepository;
            Token = tokenRepository;
            Address = address;
        }

        public async Task<int> CommitAsync()
        {
            return await _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
