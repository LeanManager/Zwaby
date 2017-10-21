using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Zwaby.Interfaces;
using System;

namespace Zwaby.Services
{
    public class APIRepository: IAPIRepository
    {
        const string Url = "http://localhost:5000";
        private string authorizationKey;

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = null;

            try { 
            client = new HttpClient();

            if (string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync(Url);
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            } catch (Exception ex) {
                var i = 5;
            }
            return client;
        }

     

        public async Task<string> ChargeCard(string token, decimal amount)
        {
            HttpClient client = await GetClient();

            var json = JsonConvert.SerializeObject(new { token, amount });

            HttpResponseMessage response = null;

            try
            {
                 response = await client.PostAsync("/api/Stripe", new StringContent(json));
            }
            catch (Exception ex)
            {
                int i = 5;
            }
                return await response.Content.ReadAsStringAsync();
        }
    }
}
