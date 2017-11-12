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
            StripeConfiguration.SetApiKey("pk_live_vC9FTyLvn4F0bW6RYV9mukG1");

            var tokenOptions = new StripeTokenCreateOptions()
            {
                Card = new StripeCreditCardOptions()
                {
                    Number = cardNumber,
                    ExpirationMonth = Int32.Parse(cardExpMonth),
                    ExpirationYear = Int32.Parse(cardExpYear),
                    Cvc = cardCVC
                }
            };

            var tokenService = new StripeTokenService();

            StripeToken stripeToken = tokenService.Create(tokenOptions);

            return stripeToken.Id;
        }
    }
}
