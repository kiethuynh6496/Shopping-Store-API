using Shopping_Store_API.DTOs.OrderDTOs;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Entities.Momo;
using Shopping_Store_API.Interface.ServiceInterface;

namespace Shopping_Store_API.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _config;

        public PaymentService(IConfiguration config)
        {
            _config = config;
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
