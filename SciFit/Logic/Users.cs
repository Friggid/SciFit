using System.Collections.Generic;
using SciFit.Models;
using System.Net.Http;
using System.Security.Cryptography;
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

        public UserModel UserLogin(string userName, string password)
        {
            var hashedPass = HashPass(password);
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsync("http://localhost:64483/api/LoginUser?username=" + userName + "&password=" + hashedPass, null).Result;

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    var result = JsonConvert.DeserializeObject<UserModel>(json);

                    return result;
                }

                return null;
            }
        }

        #region Private helpers
        private string HashPass(string pass)
        {
            var result = pass;
            using (var md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                var sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                result = sBuilder.ToString();
            }
            return result;
        }
        #endregion
    }
}