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

        public UserModel PutUser(int id, UserModel model)
        {
            UserModel result = null;
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PutAsync("http://localhost:64483/api/Users/" + id, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<UserModel>(jsonResult);
                }
                return result;
            }
        }

        public UserModel PostUser(UserModel model)
        {
            UserModel result = null;
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("http://localhost:64483/api/Users/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<UserModel>(jsonResult);
                }
                return result;
            }
        }

        public bool DeleteUser(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync("http://localhost:64483/api/Users/" + id).Result;
                return response.IsSuccessStatusCode;
            }
        }

        public UserModel UserLogin(string userName, string password)
        {
            var hashedPass = password;
            if (!IsValidMD5(password))
            {
                hashedPass = HashPass(password);
            }
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
            if (pass == null)
            {
                return null;
            }
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

        private bool IsValidMD5(string md5)
        {
            if (md5 == null || md5.Length != 32) return false;
            foreach (var x in md5)
            {
                if ((x < '0' || x > '9') && (x < 'a' || x > 'f') && (x < 'A' || x > 'F'))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}