using AutoMapper;
using CoreApiResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shopping_Store_API.Commons;
using Shopping_Store_API.DTOs;
using Shopping_Store_API.Entities;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using Stripe;

namespace Shopping_Store_API.Controllers.v1
{
	[ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/payment")]
    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        private readonly IPaymentService _paymentService;
        private readonly IShoppingCartService _shoppingCartService;

        public PaymentController(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config, IPaymentService paymentService, IShoppingCartService shoppingCartService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
            _paymentService = paymentService;
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost("create-update-payment-intent")]
        [Authorize]
        public async Task<ActionResult<ShoppingCartDTO>> CreateOrUpdatePaymentIntentAsync()
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCart(Request.Cookies["userId"], true);

            if(shoppingCart == null) throw new ApiError((int)ErrorCodes.ShoppingCartDoesntExist);

            var intent = await _paymentService.CreateOrUpdatePaymentIntent(shoppingCart);

            if (intent == null) throw new ApiError((int)ErrorCodes.ProblemCreatingPaymentIntent);

            shoppingCart.PaymentIntenId = shoppingCart.PaymentIntenId ?? intent.Id;
            shoppingCart.ClientSecret = shoppingCart.ClientSecret ?? intent.ClientSecret;

            var updateShoppingCart = _unitOfWork.ShoppingCart.Update(shoppingCart);

            if(!updateShoppingCart) throw new ApiError((int)ErrorCodes.ShoppingCartCantBeUpdated);

            var commitResult = await _unitOfWork.CommitAsync();
            if(commitResult <= 0) throw new ApiError((int)ErrorCodes.ClientRequestIsInvalid);

            var shoppingCartDTO = _mapper.Map<ShoppingCartDTO>(shoppingCart);

            return shoppingCartDTO;
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], _config["StripeSettings:WhSecret"]);

            var charge = (Charge)stripeEvent.Data.Object;

            var order = await _unitOfWork.Order.FindById(x => x.PaymentIntenId == charge.PaymentIntentId);

            PaymentIntent intent;

            switch (stripeEvent.Type)
            {
                case "payment_intent.succeeded" :
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    order.OrderStatus = Constants.OrderStatus.PaymentReceived;
                    break;
                case "payment_intent.payment_failed" :
                    intent = (PaymentIntent)stripeEvent.Data.Object;
                    order.OrderStatus = Constants.OrderStatus.PaymentFailed;
                    break;
            }

            return new EmptyResult();
        }
    }
}