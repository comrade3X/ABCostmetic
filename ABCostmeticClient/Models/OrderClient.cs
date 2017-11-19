using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class OrderClient
    {
        private string BASE_URL = "http://localhost:55863/api/orders/";

        public IEnumerable<Order> FindAll()
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("GetOrders").Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Order CreateOrder(Order order)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync("PostOrder", order).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Order>().Result;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public OrderDetails CreateOrderDetail(OrderDetails orderDetails)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync("PostOrderDetail", orderDetails).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<OrderDetails>().Result;
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Order> Search(string searchFor, DateTime? from, DateTime? to)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var json = new
                {
                    searchFor,
                    from = from?.ToString("MM/dd/yyyy"),
                    to = to?.ToString("MM/dd/yyyy"),
                };

                var response = client.PostAsJsonAsync("Search", json).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Order>>().Result;
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