using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs;
using Shopping_Store_API.Interface.ServiceInterface;
using Shopping_Store_API.Users;
using System.Diagnostics.Metrics;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : BaseController
    {
        public readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductListAsync([FromQuery]ProductParameters productParameters)
        {
            var productDetailsList = await _productService.GetProducts(productParameters);
            var productListDT0 = _mapper.Map<IEnumerable<ProductDTO>>(productDetailsList);

            return CustomResult(ResponseMesssage.DataLoadedSuccessfully.DisplayName(), productListDT0);
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
            var productListDT0 = _mapper.Map<ProductDTO>(productDetails);

            return CustomResult(ResponseMesssage.DataLoadedSuccessfully.DisplayName(), productListDT0);
        }

        /// <summary>
        /// Get product by brand name
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpGet("brand/{brand}")]
        public async Task<IActionResult> GetProdcutByBrandAsync(string brand)
        {
            var productByBrand = await _productService.GetProdcutByBrand(brand);
            var productListDT0 = _mapper.Map<IEnumerable<ProductDTO>>(productByBrand);

            return CustomResult(ResponseMesssage.DataLoadedSuccessfully.DisplayName(), productListDT0);
        }

        /// <summary>
        /// Get product by category name
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetProdcutByCategoryAsync(string category)
        {
            var productByCategory = await _productService.GetProdcutByCategory(category);
            var productListDT0 = _mapper.Map<IEnumerable<ProductDTO>>(productByCategory);

            return CustomResult(ResponseMesssage.DataLoadedSuccessfully.DisplayName(), productListDT0);
        }
    }
}
