using Microsoft.AspNetCore.Identity;
using Shopping_Store_API.Entities.ERP;
using Shopping_Store_API.Interface;
using Shopping_Store_API.Interface.ServiceInterface;
using Stripe;

namespace Shopping_Store_API.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _config;

        public PaymentService(IConfiguration config)
        {
            _config = config;
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
    }
}
