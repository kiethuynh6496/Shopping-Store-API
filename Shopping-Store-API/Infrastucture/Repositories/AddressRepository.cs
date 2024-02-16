using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DBContext;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface.RepositoryInterface;
using Shopping_Store_API.Repositories;

namespace Shopping_Store_API.Infrastucture.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
