using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        private const string productListCacheKey = "productList";
        private IMemoryCache _cache;
        private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;

        public ProductService(IUnitOfWork unitOfWork, IImageService imageService, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _cache = cache;
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

        public async Task<IEnumerable<Product>> GetProducts(ProductParameters productParameters)
        {
            if(productParameters.productName != null || 
                productParameters.orderBy != null ||
                productParameters.minPrice != 0 ||
                productParameters.maxPrice != 999999999)
            {
                var productList = _unitOfWork.Products.GetProducts(productParameters);
                return productList;
            }
            if (!_cache.TryGetValue(productListCacheKey + productParameters.pageNumber.ToString() + productParameters.pageSize.ToString(), out IEnumerable<Product> products))
            {
                try
                {
                    await semaphore.WaitAsync();
                    if (!_cache.TryGetValue(productListCacheKey + productParameters.pageNumber.ToString() + productParameters.pageSize.ToString(), out products))
                    {
                        products = _unitOfWork.Products.GetProducts(productParameters);
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromMinutes(10))
                                .SetAbsoluteExpiration(TimeSpan.FromMinutes(15))
                                .SetPriority(CacheItemPriority.Normal)
                                .SetSize(1024);
                        _cache.Set(productListCacheKey + productParameters.pageNumber.ToString() + productParameters.pageSize.ToString(), products, cacheEntryOptions);
                    }
                }
                catch
                {
                    throw new ApiError((int)ErrorCodes.DataArentLoadedSuccessfully);
                }
                finally
                {
                    semaphore.Release();
                }
            }
            return products;
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
            // Handle Brand and Category
            var currentBrand = await _unitOfWork.Brand.FindById(b => b.Name == createProductDTO.Brand.ToLower());
            var currentCategory = await _unitOfWork.Category.FindById(c => c.Name == createProductDTO.Category.ToLower());
            var currentProduct = await _unitOfWork.Products.FindById(p => p.PictureUrl == createProductDTO.PictureUrl.ToString());

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
                currentBrand = await _unitOfWork.Brand.FindById(b => b.Name == createProductDTO.Brand.ToLower());
            }
            int brandId = currentBrand.Id;

            if (currentCategory is null)
            {
                currentCategory = await _unitOfWork.Category.FindById(c => c.Name == createProductDTO.Category.ToLower());
            }
            int categoryId = currentCategory.Id;


            // Handle Image
            string productPictureURL = "";
            string publicId = "";
            if(currentProduct != null)
            {
                productPictureURL = currentProduct.PictureUrl;
                publicId = currentProduct.PublicIdCloudary;
            }
            else
            {
                if(createProductDTO.PictureUrl != null)
                {
                    var imageResult = await _imageService.AddImageAsync(createProductDTO.PictureUrl);

                    if(imageResult.Error != null) throw new ApiError((int)ErrorCodes.ImageIsntAddedSuccessfully);

                    productPictureURL = imageResult.SecureUrl.ToString();
                    publicId = imageResult.PublicId;
                }
            }

            var product = new Product
            {
                Name = createProductDTO.Name,
                Description = createProductDTO.Description,
                Price = createProductDTO.Price,
                QuantityInStock = createProductDTO.QuantityInStock,
                CategoryID = categoryId,
                BrandID = brandId,
                PictureUrl = productPictureURL,
                PublicIdCloudary = publicId,
            };

            await _unitOfWork.Products.Add(product);
            if (await _unitOfWork.CommitAsync() <= 0) throw new ApiError((int)ErrorCodes.DataArentCreatedSuccessfully);

            return product;
        }

        public async Task<Product> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var findProduct = await _unitOfWork.Products.FindById(p => p.Id == updateProductDTO.Id);

            if(findProduct is null) throw new ApiError((int)ErrorCodes.DataEntryIsNotExisted);

            // Handle Brand and Category
            var currentBrand = await _unitOfWork.Brand.FindById(b => b.Name == updateProductDTO.Brand.ToLower());
            var currentCategory = await _unitOfWork.Category.FindById(c => c.Name == updateProductDTO.Category.ToLower());

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

            if(currentBrand is null)
            {
                currentBrand = await _unitOfWork.Brand.FindById(b => b.Name == updateProductDTO.Brand.ToLower());
            }
            int brandId = currentBrand.Id;


            if (currentCategory is null)
            {
                currentCategory = await _unitOfWork.Category.FindById(c => c.Name == updateProductDTO.Category.ToLower());
            }
            int categoryId = currentCategory.Id;

            // Handle Image
            string productPictureURL = "";
            string publicId = "";

            if(updateProductDTO.PictureUrl.ToString() != findProduct.PictureUrl && updateProductDTO.PictureUrl != null)
            {
                var imageResult = await _imageService.AddImageAsync(updateProductDTO.PictureUrl);

                if(imageResult.Error != null) throw new ApiError((int)ErrorCodes.ImageIsntAddedSuccessfully);

                productPictureURL = imageResult.SecureUrl.ToString();
                publicId = imageResult.PublicId;
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
                PictureUrl = productPictureURL,
                PublicIdCloudary = publicId,
            };

            bool updateResult = _unitOfWork.Products.Update(product);
            if (!updateResult || await _unitOfWork.CommitAsync() <= 0) throw new ApiError((int)ErrorCodes.DataArentUpdatedSuccessfully);

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
