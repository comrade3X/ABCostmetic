using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class EmployeeClient
    {
        private string BASE_URL = "http://localhost:55863/api/employees/";

        public IEnumerable<Employee> FindAll()
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.GetAsync("GetEmployees").Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Employee GetEmployee(int emplId)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var query = $"?id={emplId}";

                var response = client.GetAsync("GetEmployee" + query).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Employee>().Result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Order> GetOrdersByEmployee(int emplId)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:55863/api/orders/")
                };

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var query = $"?emplId={emplId}";

                var response = client.GetAsync("GetOrderByEmployeeId" + query).Result;

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