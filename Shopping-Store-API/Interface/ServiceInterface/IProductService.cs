using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(ProductParameters productParameters);

        Task<Product> GetProductById(int productId);

        Task<IEnumerable<Product>> GetProductByCategory(string category);

        Task<IEnumerable<Product>> GetProductByBrand(string brand);

        Task<bool> CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(int productId);
    }
}
