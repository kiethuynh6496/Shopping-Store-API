using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shopping_Store_API.Commons;
using Shopping_Store_API.Entities;
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
            var productById = await _unitOfWork.Products.GetById(p => p.Id == productId);
            if (productById == null)
            {
                throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            }
            return productById;
        }

        public async Task<IEnumerable<Product>> GetProducts(ProductParameters productParameters)
        {
            var productList = await _unitOfWork.Products.GetProducts(productParameters);
            if (productList == null)
            {
                throw new ApiError((int)ErrorCodes.ProductDataDoesntExist);
            }
            return productList;
        }

        public async Task<IEnumerable<Product>> GetProdcutByBrand(string brand)
        {
            var productByBrand = await _unitOfWork.Products.GetProdcutByBrand(brand).ToListAsync();
            if (productByBrand == null)
            {
                throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            }
            return productByBrand;
        }

        public async Task<IEnumerable<Product>> GetProdcutByCategory(string category)
        {
            var productByCategory = await _unitOfWork.Products.GetProdcutByCategory(category).ToListAsync();
            if (productByCategory == null)
            {
                throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            }
            return productByCategory;
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
