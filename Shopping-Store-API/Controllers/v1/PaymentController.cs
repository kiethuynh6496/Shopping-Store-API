using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Commons;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using static Shopping_Store_API.Commons.Constants;

namespace Shopping_Store_API.Controllers.v1
{
	[ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/payment")]
    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;

        public PaymentController(IUnitOfWork unitOfWork, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
        }

        /// <summary>
        /// Create a MoMo Payment link
        /// </summary>
        /// <returns></returns>
        [HttpPost("momo")]
        public async Task<IActionResult> CreateMomoPaymentAsync()
        {
            var currentOrder = _unitOfWork.Order.GetOrderByStatus(OrderStatus.Pending, Request.Cookies["userId"]).OrderBy(o => o.CreatedDate).LastOrDefault();

            var momoResponse = _paymentService.CreateMomoPayment(currentOrder);
            return CustomResult(ResponseMesssage.DataAreCreatedSuccessfully.DisplayName(), momoResponse, System.Net.HttpStatusCode.Created);
        }
    }
}