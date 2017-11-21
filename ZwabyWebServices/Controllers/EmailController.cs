using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwabyWebServices.Models;
using Microsoft.Extensions.Configuration;

namespace ZwabyWebServices.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        IConfiguration _iconfiguration;

        public EmailController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Booking booking)
        {
            var bookingEmail = new Booking
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
                string receiver = "zwabyapp@gmail.com";
                string sender = "zwabyapp@gmail.com";
                string gmailKey = _iconfiguration["GmailKey"];

                SmtpClient client = new SmtpClient("smtp.gmail.com");

                client.EnableSsl = true;

                client.Port = 587;

                client.Credentials = new NetworkCredential("zwabyapp@gmail.com", gmailKey);

                string subject = "New Zwaby Booking";

                string body = bookingEmail.ServiceDate + ", " + bookingEmail.ServiceTime + ", " + bookingEmail.ServicePrice + ", " +
                              bookingEmail.ServiceApproximateDuration + ", " + bookingEmail.ServiceStreet + ", " +
                              bookingEmail.ServiceCity + ", " + bookingEmail.ServiceState + ", " + bookingEmail.ServiceZipCode + ", " +
                              bookingEmail.ServiceResidence + ", " + bookingEmail.ServiceBedrooms + ", " + bookingEmail.ServiceBathrooms 
                              + ", " + bookingEmail.ServiceType + ", " + bookingEmail.ServiceNotes + ", " + bookingEmail.FirstName + 
                              bookingEmail.LastName + ", " + bookingEmail.EmailAddress + ", " + bookingEmail.PhoneNumber;

                client.Send(sender, receiver, subject, body);

                client.Dispose();
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
            }

            return Ok(true);
        }
    }
}
