using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Commons;
using Shopping_Store_API.Config;
using Shopping_Store_API.DTOs.ProductDTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using Shopping_Store_API.Service.Parameters;
using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IUnitOfWork unitOfWork, IProductService productService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productService = productService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetProductListAsync([FromQuery]ProductParameters productParameters)
        {
            var productDetailsList = _productService.GetProducts(productParameters);
            var productListDT0 = _mapper.Map<IEnumerable<ProductDTO>>(productDetailsList);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), productListDT0);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            var productDetails = await _productService.GetProductById(productId);
            var productDT0 = _mapper.Map<IEnumerable<ProductDTO>>(productDetails);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), productDT0);
        }

        /// <summary>
        /// Get product by brand name
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpGet("brand/{brand}")]
        public async Task<IActionResult> GetProductByBrandAsync(string brand)
        {
            var productByBrand = await _productService.GetProductByBrand(brand);
            var productListDT0 = _mapper.Map<IEnumerable<ProductDTO>>(productByBrand);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), productListDT0);
        }

        /// <summary>
        /// Get product by category name
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetProductByCategoryAsync(string category)
        {
            var productByCategory = await _productService.GetProductByCategory(category);
            var productListDT0 = _mapper.Map<IEnumerable<ProductDTO>>(productByCategory);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), productListDT0);
        }

        /// <summary>
        /// Create product by Admin
        /// </summary>
        /// <param name="createProductDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var newProduct = await _productService.CreateProduct(createProductDTO);
            var productDT0 = _mapper.Map<ProductDTO>(newProduct);

            return CustomResult(ResponseMesssage.DataAreCreatedSuccessfully.DisplayName(), productDT0, System.Net.HttpStatusCode.Created);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateProductDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var currentProduct = await _productService.UpdateProduct(updateProductDTO);
            var productDT0 = _mapper.Map<ProductDTO>(currentProduct);

            return CustomResult(ResponseMesssage.DataAreUpdatedSuccessfully.DisplayName(), productDT0, System.Net.HttpStatusCode.OK);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            await _productService.DeleteProduct(productId);

            return CustomResult(ResponseMesssage.DataAreDeletedSuccessfully.DisplayName(), System.Net.HttpStatusCode.OK);
        }
    }
}
