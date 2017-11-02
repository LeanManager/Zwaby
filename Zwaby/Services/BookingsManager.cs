using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zwaby.Models;

namespace Zwaby.Services
{
    public class BookingsManager
    {
        const string Url = "http://zwaby.azurewebsites.net/api/bookings";
        //const string Url = "http://localhost:5000/api/bookings";

        public async Task<string> AddNewBooking(string serviceDate, string serviceTime, string servicePrice, 
                                                string serviceApproximateDuration, string serviceStreet, string serviceCity, 
                                                string serviceState, string serviceZipCode, string serviceResidence, 
                                                string serviceBedrooms, string serviceBathrooms, string serviceNotes, 
                                                DateTime serviceDateTime)
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
                ServiceNotes = serviceNotes,
                ServiceDateTime = serviceDateTime
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
