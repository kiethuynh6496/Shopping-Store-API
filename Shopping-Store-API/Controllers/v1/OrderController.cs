using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs.OrderDTOs;
using Shopping_Store_API.Interface.ServiceInterface;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/order")]
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        /// <summary>
        /// Retrieve  all Orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var ordersList = await _orderService.GetOrders(Request.Cookies["userId"]);
            var ordersListDT0 = _mapper.Map<IEnumerable<OrderResponseDTO>>(ordersList);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), ordersListDT0);
        }

        /// <summary>
        /// Retrieve the specific User's Orders by Id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet("{orderId:int}")]
        public async Task<IActionResult> GetOrderByIdAsync(int orderId)
        {
            var ordersList = await _orderService.GetOrderById(orderId, Request.Cookies["userId"]);
            var ordersListDT0 = _mapper.Map<IEnumerable<OrderResponseDTO>>(ordersList);

            return CustomResult(ResponseMesssage.DataAreLoadedSuccessfully.DisplayName(), ordersListDT0);
        }

        /// <summary>
        /// Create an Order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/v1/order
        ///     {        
        ///       "fullName": "Nguyễn Văn A",
        ///       "addressName": "12 đường số 1, Bình Thạnh",
        ///       "city": "Hồ Chí Minh",
        ///       "isDefault": true
        ///     }
        /// </remarks>
        /// <param name="orderRequestDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]OrderRequestDTO orderRequestDTO)
        {
            await _orderService.CreateOrder(Request.Cookies["userId"], orderRequestDTO);

            return CustomResult(ResponseMesssage.OrderIsCreatedSuccessfully.DisplayName(), System.Net.HttpStatusCode.Created);
        }
    }
}