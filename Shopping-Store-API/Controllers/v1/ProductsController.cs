using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Interface.ServiceInterface;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProductListAsync()
        {
            var productDetailsList = await _productService.GetAllProducts();

            return Ok(productDetailsList);
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

            return Ok(productDetails);
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

            return Ok(productByBrand);
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

            return Ok(productByCategory);
        }
    }
}
