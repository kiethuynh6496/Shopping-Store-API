using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Interface.ServiceInterface;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/shoppingcart")]
    [Authorize]
    public class ShoppingCartController : BaseController
    {
        public readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IMapper mapper, IShoppingCartService shoppingCartService)
        {
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }

        /// <summary>
        /// Get shopping cart by user id in Cookie
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetShoppingCartAsync()
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCart(Request.Cookies["userId"], false);
            var shoppingCartDT0 = _mapper.Map<ShoppingCartDTO>(shoppingCart);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), shoppingCartDT0);
        }

        /// <summary>
        /// Add product item to shopping cart
        /// </summary>
        /// <returns></returns>
        [HttpPost("update-item")]
        public async Task<IActionResult> AddItemToShoppingCartAsync([FromQuery]ShoppingCartParameters shoppingCartParameters)
        {
            var addResult = await _shoppingCartService.AddItemToShoppingCart(Request.Cookies["userId"], shoppingCartParameters, Response);

            if(!addResult)
            {
                throw new ApiError((int)ErrorCodes.DataArentCreatedSuccessfully);
            }

            return CustomResult(ResponseMesssage.DataAreCreatedSuccessfully.DisplayName(), System.Net.HttpStatusCode.Created);
        }

        /// <summary>
        /// Remove product item to shopping cart
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete-item")]
        public async Task<IActionResult> RemoveItemToShoppingCartAsync([FromQuery]ShoppingCartParameters shoppingCartParameters)
        {
            var removeResult = await _shoppingCartService.RemoveItemToShoppingCart(Request.Cookies["userId"], shoppingCartParameters);

            if (!removeResult)
            {
                throw new ApiError((int)ErrorCodes.DataArentDeletedSuccessfully);
            }

            return CustomResult(ResponseMesssage.DataAreDeletedSuccessfully.DisplayName(), System.Net.HttpStatusCode.OK);
        }
    }
}
