using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using SciFit.Models;

namespace SciFit.Logic
{
    public class PlanTemplate
    {
        public List<PlanTemplateModel> GetPlanTemplate()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:64483/api/SportTemplate/").Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<List<PlanTemplateModel>>(json);

                return result;
            }
        }

        public PlanTemplateModel GetPlanTemplateById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync("http://localhost:64483/api/SportTemplate/" + id).Result;

                var json = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<PlanTemplateModel>(json);

                return result;
            }
        }

        public PlanTemplateModel PutPlanTemplate(PlanTemplateModel model)
        {
            PlanTemplateModel result = null;
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PutAsync("http://localhost:64483/api/SportTemplate/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<PlanTemplateModel>(jsonResult);
                }
                return result;
            }
        }

        public PlanTemplateModel PostPlanTemplate(PlanTemplateModel model)
        {
            PlanTemplateModel result = null;
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(model);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync("http://localhost:64483/api/SportTemplate/", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = response.Content.ReadAsStringAsync().Result;

                    result = JsonConvert.DeserializeObject<PlanTemplateModel>(jsonResult);
                }
                return result;
            }
        }

        public void DeletePlanTemplate(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.DeleteAsync("http://localhost:64483/api/SportTemplate/" + id).Result;
            }
        }
    }
}