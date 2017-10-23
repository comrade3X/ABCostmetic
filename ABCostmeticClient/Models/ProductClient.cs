using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;

namespace ABCostmeticClient.Models
{
    public class ProductClient
    {
        private string BASE_URL = "http://localhost:55863/api/";

        public IEnumerable<Product> FindAll()
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("products").Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}