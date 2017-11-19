using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class CustomerClient
    {
        private readonly string BASE_URL = "http://localhost:55863/api/customers/";

        public Customer Create(Customer customer)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync("PostCustomer", customer).Result;

                return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<Customer>().Result : null;
            }
            catch
            {
                return null;
            }
        }
    }
}