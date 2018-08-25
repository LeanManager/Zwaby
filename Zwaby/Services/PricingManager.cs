using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Zwaby.Models;

namespace Zwaby.Services
{
    public class PricingManager
    {
        private string Url = "Your_Azure_API_Url";

        public async Task<List<string>> GeneratePriceAndDuration(string bedrooms, string bathrooms, string residence, string serviceType)
        { 
            PricingVariables variables = new PricingVariables()
            {
                Bedrooms = bedrooms,
                Bathrooms = bathrooms,
                ResidenceType = residence,
                ServiceType = serviceType
            };

            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            // Use the PostAsync method against the base URL to add the book.
            // Create the HttpContent from the JSON string by creating a new StringContent object, 
            // use the constructor which also takes an encoding and media type.
            response = await client.PostAsync(Url, new StringContent(JsonConvert.SerializeObject(variables),
                                                                     Encoding.UTF8, "application/json"));
            
            return JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
            
        }
    }
}
