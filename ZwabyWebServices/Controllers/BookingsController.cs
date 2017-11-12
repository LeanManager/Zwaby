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
    public class BookingsController : Controller
    {
        private readonly BookingsContext _context;

        public BookingsController(BookingsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Booking booking)
        {
            var bookingEntry = new Booking
            {
                ServiceDate = booking.ServiceDate,
                ServiceTime = booking.ServiceTime,
                ServicePrice = booking.ServicePrice,
                ServiceApproximateDuration = booking.ServiceApproximateDuration,
                ServiceStreet = booking.ServiceStreet,
                ServiceCity = booking.ServiceCity,
                ServiceState = booking.ServiceState,
                ServiceZipCode = booking.ServiceZipCode,
                ServiceResidence = booking.ServiceResidence,
                ServiceBedrooms = booking.ServiceBedrooms,
                ServiceBathrooms = booking.ServiceBathrooms,
                ServiceType = booking.ServiceType,
                ServiceNotes = booking.ServiceNotes,
                ServiceDateTime = booking.ServiceDateTime,
                FirstName = booking.FirstName,
                LastName = booking.LastName,
                EmailAddress = booking.EmailAddress,
                PhoneNumber = booking.PhoneNumber
            };

            try
            {
                _context.Add(bookingEntry);
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
