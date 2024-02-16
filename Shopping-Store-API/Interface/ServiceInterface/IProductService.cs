using Shopping_Store_API.DTOs.ProductDTOs;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(ProductParameters productParameters);

        Task<IEnumerable<Product>> GetProductById(int productId);

        Task<IEnumerable<Product>> GetProductByCategory(string category);

        Task<IEnumerable<Product>> GetProductByBrand(string brand);

        Task<Product> CreateProduct(CreateProductDTO createProductDTO);

        Task<Product> UpdateProduct(UpdateProductDTO updateProductDTO);

        Task<bool> DeleteProduct(int productId);
    }
}
