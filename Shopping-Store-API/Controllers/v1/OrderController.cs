﻿using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface.ServiceInterface;
using Microsoft.AspNetCore.Authorization;

namespace Shopping_Store_API.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/order")]
    //[Authorize]
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
        /// Get all orders
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
        /// Get order by id
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
        /// 
        /// </summary>
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