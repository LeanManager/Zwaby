using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwabyWebServices.Models;

namespace ZwabyWebServices.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly RegistrationContext _context;

        public RegistrationController(RegistrationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            var customerEntry = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber,
                DateAdded = DateTime.Now,
                Password = customer.Password
            };

            try
            {
                _context.Add(customerEntry);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return Ok(true);
        }
    }
}
