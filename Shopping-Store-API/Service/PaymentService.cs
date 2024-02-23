using Shopping_Store_API.DTOs.OrderDTOs;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Entities.Momo;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using Stripe;

namespace Shopping_Store_API.Service
{
	public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IConfiguration config, IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymentIntent> CreateOrUpdatePaymentIntent(ShoppingCart shoppingCart)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];

            var service = new PaymentIntentService();

            var intent = new PaymentIntent();

            var total = shoppingCart.ShoppingCartItems.Sum(item => item.Quantity * item.Item.Price);

           if (string.IsNullOrEmpty(shoppingCart.PaymentIntenId))
           {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = total,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                intent = await service.CreateAsync(options);
           }
           else
           {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = total
                };
                await service.UpdateAsync(shoppingCart.PaymentIntenId, options);
           }
           return intent;
        }

        public MomoResponseDTO CreateMomoPayment(Order order)
        {
            string partnerCode = _config["Momo:PartnerCode"] ?? string.Empty;
            string PaymentUrl = _config["Momo:PaymentUrl"] ?? string.Empty;
            string requestId = order.MomoRequestId ?? string.Empty;
            long amount = order.Total;
            string orderId = order.Id.ToString();
            string orderInfo = "Thanh toán đơn hàng " + orderId;
            string returnUrl = _config["Momo:ReturnUrl"] ?? string.Empty;
            string ipnUrl = _config["Momo:IpnUrl"] ?? string.Empty;
            string accessKey = _config["Momo:AccessKey"] ?? string.Empty;
            string secretKey = _config["Momo:SecretKey"] ?? string.Empty;
            string requestType = "captureWallet";
            string extraData = string.Empty;

            var paymentUrl = string.Empty;

            var momoOneTimePayRequest = new MomoOneTimePaymentRequest(partnerCode, requestId, amount, orderId, orderInfo, returnUrl, ipnUrl, requestType, extraData);
            momoOneTimePayRequest.MakeSignature(accessKey, secretKey);
            (bool createMomoLinkResult, string? createMessage) = momoOneTimePayRequest.GetLink(PaymentUrl);
            if (createMomoLinkResult)
            {
                paymentUrl = createMessage;
            }
            else
            {
                paymentUrl = createMessage;
            }
            var result = new MomoResponseDTO
            {
                OrderID = orderId,
                PaymentMomoURL = paymentUrl
            };
            return result;
        }
    }
}
