using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using ZwabyWebServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZwabyWebServices.Controllers
{
    [Route("api/Stripe")]
    public class StripeController : Controller
    {
		private readonly StripeContext _context;

		 //The constructor uses Dependency Injection to inject the database context (StripeContext) into the controller. 
		 //The database context is used in each of the CRUD methods in the controller.
		 //The constructor adds an item to the in-memory database if one doesn't exist.

		public StripeController(StripeContext context)
		{
			_context = context;

			if (_context.StripeCharges.Count() == 0)
			{
				_context.StripeCharges.Add(new StripeItem { });
				_context.SaveChanges();
			}
		}

		// POST api/Stripe
		//     [HttpPost]
		//     public IActionResult Post([FromBody] StripeItem item)
		//     {
		//if (item == null)
		//{
		//	return BadRequest();
		//}
		//_context.StripeCharges.Add(item);
		//_context.SaveChanges();
		//    return CreatedAtRoute("GetStripe", new { id = item.Id }, item);
		//}

        [HttpPost]
		public IActionResult Charge(string stripeToken, decimal amount)
		{
			var customers = new StripeCustomerService();
			var charges = new StripeChargeService();

			var customer = customers.Create(new StripeCustomerCreateOptions
			{
				SourceToken = stripeToken
			});

			var charge = charges.Create(new StripeChargeCreateOptions
			{
				Amount = (int)amount,
				Description = "Sample Charge",
				Currency = "usd",
				CustomerId = customer.Id
			});

			return View();
		}

    }
}
