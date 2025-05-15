using Stripe;
using Microsoft.Extensions.Configuration;

namespace TicketingApp.Services
{
    public class StripeService
    {
        private readonly string _apiKey;

        public StripeService(IConfiguration configuration)
        {
            _apiKey = configuration["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _apiKey;
        }

        public async Task<PaymentIntent> CreatePaymentIntentAsync(long amount, string currency)
        {
            var options = new PaymentIntentCreateOptions
            {
                Amount = amount,
                Currency = currency,
            };

            var service = new PaymentIntentService();
            return await service.CreateAsync(options);
        }
    }
}