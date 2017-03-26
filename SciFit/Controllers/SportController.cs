using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class SportController : Controller
    {
        private readonly GeneratePlan _generatePlan;

        public SportController(GeneratePlan generatePlan)
        {
            _generatePlan = generatePlan;
        }

        public ActionResult SportPlan(User user)
        {
            var plan = new SportNutritionPlanModel
            {
                SportPlan = _generatePlan.GenerateSportPlan(user),
                NutritionPlan = _generatePlan.GenerateNutritionPlan(user)
            };

            return View("Plan", plan);
        }
    }
}