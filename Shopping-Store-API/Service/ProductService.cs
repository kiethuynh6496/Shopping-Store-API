using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs.ProductDTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Service
{
	public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetProductById(int productId)
        {
            var productById = await _unitOfWork.Products.GetProdcutById(productId).ToListAsync();
            if (productById == null)
            {
                throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            }
            return productById;
        }

        public IEnumerable<Product> GetProducts(ProductParameters productParameters)
        {
            var productList = _unitOfWork.Products.GetProducts(productParameters);
            if (productList == null)
            {
                throw new ApiError((int)ErrorCodes.ProductDataDoesntExist);
            }
            return productList;
        }

        public async Task<IEnumerable<Product>> GetProductByBrand(string brand)
        {
            var productByBrand = await _unitOfWork.Products.GetProdcutByBrand(brand).ToListAsync();
            if (productByBrand == null)
            {
                throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            }
            return productByBrand;
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string category)
        {
            var productByCategory = await _unitOfWork.Products.GetProdcutByCategory(category).ToListAsync();
            if (productByCategory == null)
            {
                throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);
            }
            return productByCategory;
        }

        public async Task<Product> CreateProduct(CreateProductDTO createProductDTO)
        {
            var currentBrand = await _unitOfWork.Brand.FindById(b => b.Name == createProductDTO.Brand.ToLower());
            var currentCategory = await _unitOfWork.Category.FindById(b => b.Name == createProductDTO.Category.ToLower());
            int categoryId;
            int brandId;

            if(currentBrand is null)
            {
                var newBrand = new Brand
                {
                    Name = createProductDTO.Brand
                };
                await _unitOfWork.Brand.Add(newBrand);
            }

            if(currentCategory is null)
            {
                var newCategory = new Category
                {
                    Name = createProductDTO.Category
                };
                await _unitOfWork.Category.Add(newCategory);
            }

            if(currentBrand is null || currentCategory is null)
            {
                if (await _unitOfWork.CommitAsync() <= 0) throw new ApiError((int)ErrorCodes.DataArentCreatedSuccessfully);
            }

            if(currentBrand is null)
            {
                var tempBrand = await _unitOfWork.Brand.FindById(b => b.Name == createProductDTO.Brand.ToLower());
                brandId = tempBrand.Id;
            }
            else
            {
                brandId = currentBrand.Id;
            }

            if (currentCategory is null)
            {
                var tempCategory = await _unitOfWork.Category.FindById(b => b.Name == createProductDTO.Category.ToLower());
                categoryId = tempCategory.Id;
            }
            else
            {
                categoryId = currentCategory.Id;
            }

            var product = new Product
            {
                Name = createProductDTO.Name,
                Description = createProductDTO.Description,
                Price = createProductDTO.Price,
                QuantityInStock = createProductDTO.QuantityInStock,
                CategoryID = categoryId,
                BrandID = brandId,
            };

            await _unitOfWork.Products.Add(product);
            if (await _unitOfWork.CommitAsync() <= 0) throw new ApiError((int)ErrorCodes.DataArentCreatedSuccessfully);

            return product;
        }

        public async Task<Product> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var findProduct = await _unitOfWork.Products.FindById(p => p.Id == updateProductDTO.Id);

            if(findProduct is null) throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);

            var currentBrand = await _unitOfWork.Brand.FindById(b => b.Name == updateProductDTO.Brand.ToLower());
            var currentCategory = await _unitOfWork.Category.FindById(b => b.Name == updateProductDTO.Category.ToLower());

            if(currentBrand is null)
            {
                var newBrand = new Brand
                {
                    Name = updateProductDTO.Brand
                };
                await _unitOfWork.Brand.Add(newBrand);
            }

            if(currentCategory is null)
            {
                var newCategory = new Category
                {
                    Name = updateProductDTO.Category
                };
                await _unitOfWork.Category.Add(newCategory);
            }

            if(currentBrand is null || currentCategory is null)
            {
                if (await _unitOfWork.CommitAsync() <= 0) throw new ApiError((int)ErrorCodes.DataArentCreatedSuccessfully);
            }

            int brandId;
            int categoryId;
            if(currentBrand is null)
            {
                var tempBrand = await _unitOfWork.Brand.FindById(b => b.Name == updateProductDTO.Brand.ToLower());
                brandId = tempBrand.Id;
            }
            else
            {
                brandId = currentBrand.Id;
            }

            if (currentCategory is null)
            {
                var tempCategory = await _unitOfWork.Category.FindById(b => b.Name == updateProductDTO.Category.ToLower());
                categoryId = tempCategory.Id;
            }
            else
            {
                categoryId = currentCategory.Id;
            }

            var product = new Product
            {
                Id = updateProductDTO.Id,
                Name = updateProductDTO.Name,
                Description = updateProductDTO.Description,
                Price = updateProductDTO.Price,
                QuantityInStock = updateProductDTO.QuantityInStock,
                CategoryID = categoryId,
                BrandID = brandId,
            };

            bool updateResult = _unitOfWork.Products.Update(product);
            if (!updateResult || await _unitOfWork.CommitAsync() <= 0) throw new ApiError((int)ErrorCodes.DataArentCreatedSuccessfully);

            return product;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var findProduct = await _unitOfWork.Products.FindById(p => p.Id == productId);

            if(findProduct is null) throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);

            var deleteResult = _unitOfWork.Products.Delete(findProduct);
            if(!deleteResult || await _unitOfWork.CommitAsync() <= 0) throw new ApiError((int)ErrorCodes.DataArentDeletedSuccessfully);

            return deleteResult;
        }
    }
}
