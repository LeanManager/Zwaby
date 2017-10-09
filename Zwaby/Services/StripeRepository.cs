using System;
using System.Collections.Generic;
using System.Text;
using Stripe;
using Zwaby.Interfaces;

namespace Zwaby.Services
{
    public class StripeRepository: IStripeRepository
    {
        public string CreateToken(string cardNumber, string cardExpMonth, string cardExpYear, string cardCVC)
        {
            StripeConfiguration.SetApiKey("pk_test_oO54O2GJQQMEjY1BUDVoRZ01");

            //TODO: Wireup card information below

            var tokenOptions = new StripeTokenCreateOptions()
            {
                Card = new StripeCreditCardOptions()
                {
                    Number = "4242424242424242",
                    ExpirationYear = 2018,
                    ExpirationMonth = 10,
                    Cvc = "123"
                }
            };

            var tokenService = new StripeTokenService();

            StripeToken stripeToken = tokenService.Create(tokenOptions);

            return stripeToken.Id;
        }

    }
}
