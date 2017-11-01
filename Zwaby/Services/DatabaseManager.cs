using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zwaby.Models;

namespace Zwaby.Services
{
    public class DatabaseManager
    {
        const string Url = "http://zwaby.azurewebsites.net/api/registration";
        //const string Url = "http://localhost:5000/api/registration";

        public async Task<string> AddNewCustomer(string firstName, string lastName, string emailAddress, string phoneNumber)
        {
            Customer customer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            response = await client.PostAsync(Url,
                                              new StringContent(JsonConvert.SerializeObject(customer),
                                              Encoding.UTF8, "application/json"));

            return await response.Content.ReadAsStringAsync();
        }
    }
}
