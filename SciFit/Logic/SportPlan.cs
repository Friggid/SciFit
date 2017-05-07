using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using SciFit.Models;

namespace SciFit.Logic
{
    public class SportPlan
    {
        public SportPlanModel GetAllSportPlansById(int userId)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:64483/api/Sport/" + userId + "?var=" + null).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<SportPlanModel>(json);

                return result;
            }
        }

        public SportPlanModel GetSportPlanById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:64483/api/Sport/" + id).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<SportPlanModel>(json);

                return result;
            }
        }

        public SportPlanModel PutSportDone(int id, int sportId)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PutAsync("http://localhost:64483/api/Sport/" + id + "?sportId=" + sportId, null).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<SportPlanModel>(json);

                return result;
            }
        }

        public SportPlanModel PostSportPlan(int id, int level)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.PostAsync("http://localhost:64483/api/Sport/" + id + "?level=" + level, null).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<SportPlanModel>(json);

                return result;
            }
        }

        public void DeleteSportPlan(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync("http://localhost:64483/api/Sport/" + id).Result;
            }
        }
    }
}