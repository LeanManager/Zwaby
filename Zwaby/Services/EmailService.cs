using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zwaby.Models;

namespace Zwaby.Services
{
    public class EmailService
    {
        const string Url = "https://zwaby.azurewebsites.net/api/email";

        public async Task<string> SendEmail(string serviceDate, string serviceTime, string servicePrice,
                                            string serviceApproximateDuration, string serviceStreet, string serviceCity,
                                            string serviceState, string serviceZipCode, string serviceResidence,
                                            string serviceBedrooms, string serviceBathrooms, string serviceType, string serviceNotes,
                                            DateTime serviceDateTime, string firstName, string lastName, string email, string phone)
        {
            Booking booking = new Booking
            {
                ServiceDate = serviceDate,
                ServiceTime = serviceTime,
                ServicePrice = servicePrice,
                ServiceApproximateDuration = serviceApproximateDuration,
                ServiceStreet = serviceStreet,
                ServiceCity = serviceCity,
                ServiceState = serviceState,
                ServiceZipCode = serviceZipCode,
                ServiceResidence = serviceResidence,
                ServiceBedrooms = serviceBedrooms,
                ServiceBathrooms = serviceBathrooms,
                ServiceType = serviceType,
                ServiceNotes = serviceNotes,
                ServiceDateTime = serviceDateTime,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email,
                PhoneNumber = phone
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            response = await client.PostAsync(Url,
                                              new StringContent(JsonConvert.SerializeObject(booking),
                                              Encoding.UTF8, "application/json"));

            return await response.Content.ReadAsStringAsync();
        }
    }
}
