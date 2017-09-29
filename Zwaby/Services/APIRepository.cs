using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Zwaby.Interfaces;

namespace Zwaby.Services
{
    public class APIRepository
    {
        const string Url = "https://api.stripe.com";
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

        public async void Charge()
        {
            HttpClient client = await GetClient();

            string result = await client.GetStringAsync(Url);

            //return JsonConvert.DeserializeObject()

            DependencyService.Get<IStripe>().Charge();
        }


    }
}
