using Shopping_Store_API.DBContext;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.RepositoryInterface;

namespace Shopping_Store_API.Infrastucture
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbFactory _dbFactory;
        public IProductRepository Products { get; }

        public UnitOfWork(DbFactory dbFactory, IProductRepository productRepository)
        {
            _dbFactory = dbFactory;
            Products = productRepository;
        }

        public Task<int> CommitAsync()
        {
            return _dbFactory.DbContext.SaveChangesAsync();
        }
    }
}
