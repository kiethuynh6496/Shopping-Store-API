using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs.ShoppingCartDTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Interface.ServiceInterface;
using Shopping_Store_API.Service.Parameters;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/shoppingcart")]
    //[Authorize]
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IMapper mapper, IShoppingCartService shoppingCartService)
        {
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }

        /// <summary>
        /// Retrieve Shopping Cart by userId in Cookie
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetShoppingCartAsync()
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCart(Request.Cookies["userId"], false);
            var shoppingCartDT0 = _mapper.Map<ShoppingCartDTO>(shoppingCart);

            return CustomResult(ResponseMesssage.ShoppingCartIsLoadedSuccessfully.DisplayName(), shoppingCartDT0);
        }

        /// <summary>
        /// Add an Item to Cart
        /// </summary>
        /// <returns></returns>
        [HttpPost("update-item")]
        public async Task<IActionResult> AddItemToShoppingCartAsync([FromQuery]ShoppingCartParameters shoppingCartParameters)
        {
            var addResult = await _shoppingCartService.AddItemToShoppingCart(Request.Cookies["userId"], shoppingCartParameters, Response);

            if(addResult is null) throw new ApiError((int)ErrorCodes.DataArentCreatedSuccessfully);

            var shoppingCartDT0 = _mapper.Map<ShoppingCartDTO>(addResult);

            return CustomResult(ResponseMesssage.ItemIsAddedSuccessfully.DisplayName(), shoppingCartDT0, System.Net.HttpStatusCode.Created);
        }

        /// <summary>
        /// Remove an Item to Cart
        /// </summary>
        /// <returns></returns>
        [HttpDelete("delete-item")]
        public async Task<IActionResult> RemoveItemToShoppingCartAsync([FromQuery]ShoppingCartParameters shoppingCartParameters)
        {
            var removeResult = await _shoppingCartService.RemoveItemToShoppingCart(Request.Cookies["userId"], shoppingCartParameters);

            if (removeResult is null) throw new ApiError((int)ErrorCodes.DataArentDeletedSuccessfully);

            var shoppingCartDT0 = _mapper.Map<ShoppingCartDTO>(removeResult);

            return CustomResult(ResponseMesssage.ItemIsRemovedSuccessfully.DisplayName(), shoppingCartDT0, System.Net.HttpStatusCode.OK);
        }
    }
}
