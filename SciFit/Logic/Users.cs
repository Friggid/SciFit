using System.Collections.Generic;
using SciFit.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace SciFit.Logic
{
    public class Users
    {
        public List<UserModel> GetUsers()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:64483/api/Users").Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<UserModel>>(json);

                return result;
            }
        }

        public UserModel GetUser(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:64483/api/Users/" + id).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<UserModel>(json);

                return result;
            }
        }

        public bool PutUser(int id, UserModel model)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PutAsync("http://localhost:64483/api/Users/" + id, content).Result;

                return response.IsSuccessStatusCode;
            }
        }

        public bool PostUser(UserModel model)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("http://localhost:64483/api/Users/", content).Result;

                return response.IsSuccessStatusCode;
            }
        }
    }
}