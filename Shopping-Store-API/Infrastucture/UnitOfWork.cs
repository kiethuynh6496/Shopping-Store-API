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

        public UnitOfWork(DbFactory dbFactory, IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _dbFactory = dbFactory;
            Products = productRepository;
            ShoppingCart = shoppingCartRepository;
            ShoppingCartItem = shoppingCartItemRepository;
        }

        public Task<int> CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }

        public void Modify<TEntity>(TEntity entity) where TEntity : class
        {
            var entry = _dbFactory.DbContext.Entry(entity);

            if (entry != null)
            {
                entry.State = EntityState.Modified;
            }
        }
    }
}
