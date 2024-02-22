using Shopping_Store_API.DTOs.OrderDTOs;
using Shopping_Store_API.Entities.ERP;
using Stripe;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface IPaymentService
    {
        Task<PaymentIntent> CreateOrUpdatePaymentIntent(ShoppingCart shoppingCart);
        MomoResponseDTO CreateMomoPayment(Order order);
    }
}
