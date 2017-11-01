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
            // TODO: Logic to add row to appropriate Customers table in Azure (using zwabydb.database.windows.net)
            // Create Customer table beforehand, with appropriate columns

            //using (var db = new RegistrationContext())
            //{
            //    var customerEntry = new Customer
            //    {
            //        FirstName = customer.FirstName,
            //        LastName = customer.LastName,
            //        EmailAddress = customer.EmailAddress,
            //        PhoneNumber = customer.PhoneNumber
            //    };
            //    db.Customers.Add(customerEntry);
            //    db.SaveChanges();
            //}

            var customerEntry = new Customer
            {
                Id = 1,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber,
                DateAdded = DateTime.Now
            };

            try
            {
                _context.Add(customerEntry);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return Ok(true);
        }
    }
}
