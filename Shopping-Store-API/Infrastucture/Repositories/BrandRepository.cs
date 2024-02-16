using Shopping_Store_API.DBContext;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface.RepositoryInterface;
using Shopping_Store_API.Repositories;

namespace Shopping_Store_API.Infrastucture.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
