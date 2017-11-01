using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using ZwabyWebServices.Models;

namespace ZwabyWebServices.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        // POST api/payment
        [HttpPost]
        public IActionResult Post([FromBody]PaymentModel payment)
        {
            // Use the Stripe Nuget Package here, and actually charge the credit card.
            // Because this is just an example, you can hard code the Stripe Secret and Publishable Key here
            // This WebApi will then need to be hosted on a server, e.g. Azure

            //var customers = new StripeCustomerService();
            //var charges = new StripeChargeService();
            //var customer = customers.Create(new StripeCustomerCreateOptions
            //{
            //    Email = payment.Email,
            //    SourceToken = payment.Token
            //});
            //var charge = charges.Create(new StripeChargeCreateOptions
            //{
            //    Amount = payment.Amount, // in cents
            //    Description = "Booking price",
            //    Currency = "usd",
            //    CustomerId = customer.Id
            //});

            // TODO: Get SecretKey from appsettings.json

            StripeConfiguration.SetApiKey("sk_test_t0PxK1ifMhrPBI8LXM8zk6eD");

            var chargeOptions = new StripeChargeCreateOptions()
            {
                Amount = payment.Amount,
                Currency = "usd",
                Description = "Zwaby Charge",
                SourceTokenOrExistingSourceId = payment.Token
            };

            var chargeService = new StripeChargeService();
            StripeCharge charge = chargeService.Create(chargeOptions);

            // Once the payment is made, return the result here
            // Please note that this way of doing things, is just because this is just a proof of concept app for you.
            // In a production system, because someone could spoof the API on their end, they could always trick the mobile app.
            // But you can work on that in the next step.

            return Ok(true); 
            // Ideally you would put in additional information, but you can just return true or false for the moment.

        }

    }
}
