using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class SportController : Controller
    {
        public ActionResult SportPlan(UserModel user)
        {
            var generatePlan = new GeneratePlan();
            //get users from API 
            var users = new Users();

            users.PutUser(1, user);

            //var plan = new SportNutritionPlanModel
            //{
            //    SportPlan = generatePlan.GenerateSportPlan(user),
            //    NutritionPlan = generatePlan.GenerateNutritionPlan(user)
            //};

            //return View("Plan", plan);
            return null;
        }
    }
}