using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Zwaby.Interfaces;
using System;
using System.Diagnostics;
using Zwaby.Models;
using System.Text;

namespace Zwaby.Services
{
    public class APIRepository: IAPIRepository
    {
        const string Url = "http://zwaby.azurewebsites.net/api/payment";
        //private string authorizationKey;

        //private async Task<HttpClient> GetClient()
        //{
        //    try 
        //    { 
        //        HttpClient client = new HttpClient();
        //        if (string.IsNullOrEmpty(authorizationKey))
        //        {
        //            authorizationKey = await client.GetStringAsync(Url);
        //            authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
        //        }
        //        client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
        //        client.DefaultRequestHeaders.Add("Accept", "application/json");
        //        return client;
        //    } 
        //    catch (Exception ex) 
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //}

        public async Task<string> ChargeCard(string token, int amount)
        {
            //HttpClient client = await GetClient();
            //var json = JsonConvert.SerializeObject(new { token, amount });
            //HttpResponseMessage response = null;
            //try
            //{
            //     response = await client.PostAsync("/api/Stripe", new StringContent(json));
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //}
            //return await response.Content.ReadAsStringAsync();

            HttpClient client = new HttpClient();
            HttpResponseMessage response;

            response = await client.PostAsync(Url, 
                             new StringContent(JsonConvert.SerializeObject(new PaymentModel() 
                                                                           { 
                                                                               Email = "zwabyapp@gmail.com", 
                                                                               Token = token,
                                                                               Amount = amount
                                                                           }), 
                                               Encoding.UTF8, "application/json"));
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}
