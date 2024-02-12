using Shopping_Store_API.Entities.ERP;
using Stripe;

namespace Shopping_Store_API.Interface.ServiceInterface
{
    public interface IPaymentService
    {
        Task<PaymentIntent> CreateOrUpdatePaymentIntent(ShoppingCart shoppingCart);
    }
}
