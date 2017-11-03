﻿using System;
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
