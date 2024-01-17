using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities.ERP;

namespace Shopping_Store_API.Interface.RepositoryInterface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetProdcutByCategory(string category);
        IQueryable<Product> GetProdcutByBrand(string brand);
        Task<IEnumerable<Product>> GetProducts(ProductParameters productParameters);
    }
}
