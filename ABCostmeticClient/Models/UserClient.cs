using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ABCostmeticClient.Models
{
    public class UserClient
    {
        private string BASE_URL = "http://localhost:55863/api/users/";

        public User Login(User user)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync("login", user).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<User>().Result;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public StaffType GetUserRole(int emplId)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BASE_URL)
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var query = $"?emplId={emplId}";
                var response = client.GetAsync("getuserrole" + query).Result;

                return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<StaffType>().Result : null;
            }
            catch
            {
                return null;
            }
        }
    }
}