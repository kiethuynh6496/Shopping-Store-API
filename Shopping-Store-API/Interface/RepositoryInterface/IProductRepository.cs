using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Interface.RepositoryInterface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProducts(ProductParameters productParameters);
        IQueryable<Product> GetProdcutByCategory(string category);
        IQueryable<Product> GetProdcutByBrand(string brand);
    }
}
