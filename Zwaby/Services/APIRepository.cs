using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Zwaby.Interfaces;

namespace Zwaby.Services
{
    public class APIRepository: IAPIRepository
    {
        const string Url = "https://yourlocalapi.com";
        private string authorizationKey;

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();

            if (string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync(Url);
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);

            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

     

        public async Task<string> ChargeCard(string token, decimal amount)
        {
            HttpClient client = await GetClient();

            var json = JsonConvert.SerializeObject(new { token, amount });

            var response = await client.PostAsync("/api/payment", new StringContent(json));

            return await response.Content.ReadAsStringAsync();

        }
    }
}
