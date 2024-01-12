using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;

namespace Shopping_Store_API.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Products.GetById(p => p.Id == productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var productDetailsList = await _unitOfWork.Products.GetAll();
            return productDetailsList;
        }

        public async Task<IEnumerable<Product>> GetProdcutByBrand(string brand)
        {
            if (!brand.IsNullOrEmpty())
            {
                var productByBrand = await _unitOfWork.Products.GetProdcutByBrand(brand).ToListAsync();
                if (productByBrand != null)
                {
                    return productByBrand;
                }
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetProdcutByCategory(string category)
        {
            if (!category.IsNullOrEmpty())
            {
                var productByCategory = await _unitOfWork.Products.GetProdcutByCategory(category).ToListAsync();
                if (productByCategory != null)
                {
                    return productByCategory;
                }
            }
            return null;
        }

        public Task<bool> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
