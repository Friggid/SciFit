using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using SciFit.Models;


namespace SciFit.Logic
{
    public class Statistics
    {
        public List<StatisticsModel> GetStatistics()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:64483/api/Statistics/").Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<StatisticsModel>>(json);

                return result;
            }
        }

        public StatisticsModel GetStatisticsById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:64483/api/Statistics/" + id).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<StatisticsModel>(json);

                return result;
            }
        }

        public StatisticsModel PutStatistics(StatisticsModel model)
        {
            StatisticsModel result = null;
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PutAsync("http://localhost:64483/api/Statistics/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<StatisticsModel>(jsonResult);
                }
                return result;
            }
        }

        public StatisticsModel PostStatistics(StatisticsModel model)
        {
            StatisticsModel result = null;
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("http://localhost:64483/api/Statistics/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<StatisticsModel>(jsonResult);
                }
                return result;
            }
        }

        public void DeleteStatistics(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync("http://localhost:64483/api/Statistics/" + id).Result;
            }
        }
    }
}