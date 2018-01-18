using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ZwabyWebServices.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZwabyWebServices.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        IConfiguration _iconfiguration;

        public NotificationController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            var notificationEmail = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                EmailAddress = customer.EmailAddress
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

                string subject = "Zwaby User Input Data";

                string body = notificationEmail.FirstName + ", " + notificationEmail.LastName + ", " + 
                              notificationEmail.EmailAddress + ", " + notificationEmail.PhoneNumber;

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
