using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zwaby.Models;

namespace Zwaby.Services
{
    public class CancellationsManager
    {
        const string Url = "https://zwaby.azurewebsites.net/api/cancellations";

        public async Task<string> AddNewCancellation(string cancellationReason, DateTime cancellationDate, string firstName,
                                                     string lastName, string emailAddress, string phoneNumber)
        {
            Cancellation cancellation = new Cancellation
            {
                CancellationReason = cancellationReason,
                CancellationDate = cancellationDate,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                PhoneNumber = phoneNumber
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            response = await client.PostAsync(Url,
                                              new StringContent(JsonConvert.SerializeObject(cancellation),
                                              Encoding.UTF8, "application/json"));

            return await response.Content.ReadAsStringAsync();
        }
    }
}
