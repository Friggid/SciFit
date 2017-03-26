using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class SportController : Controller
    {
        public ActionResult SportPlan(User user)
        {
            var generatePlan = new GeneratePlan();

            var plan = new SportNutritionPlanModel
            {
                SportPlan = generatePlan.GenerateSportPlan(user),
                NutritionPlan = generatePlan.GenerateNutritionPlan(user)
            };

            return View("Plan", plan);
        }
    }
}