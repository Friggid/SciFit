using System.Dynamic;
using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class SportController : Controller
    {
        public ActionResult SportPlan(UserModel userModel)
        {
            //Hardcoded for normal user
            userModel.RoleId = 1;

            var users = new Users();

            if (users.PostUser(userModel))
            {
                return RedirectToAction("Login", "Authentication");
            }

            return RedirectToAction("Login", "Authentication");
        }

        public ActionResult Login(UserModel userModel)
        {
            var generatePlan = new GeneratePlan();
            var user = new Users();
            var sportPlan = new SportPlan();

            var loggedInData = user.UserLogin(userModel.UserName, userModel.Password);

            if (loggedInData != null)
            {
                var userData = new SportNutritionPlanModel
                {
                    SportPlan = generatePlan.GenerateSportPlan(loggedInData),
                    NutritionPlan = generatePlan.GenerateNutritionPlan(loggedInData),
                    User = loggedInData
                };

                if (userData.SportPlan.Count <= 0)
                {
                    userData.SportPlan = sportPlan.PostSportPlan(loggedInData.Id, 1).Sport;// temp fix lvl nr 1
                }
                return View("Plan", userData);
            }

            return RedirectToAction("Login", "Authentication");
        }

        public ActionResult UpdatePlan(int id, int sportId, int lvl)
        {
            var generatePlan = new GeneratePlan();
            var user = new Users();
            var sportPlan = new SportPlan();

            var loggedInData = user.GetUser(id);

            var userData = new SportNutritionPlanModel
            {
                SportPlan = sportPlan.PutSportDone(id, sportId).Sport,
                NutritionPlan = generatePlan.GenerateNutritionPlan(loggedInData),
                User = loggedInData
            };
            if (userData.SportPlan.Count <= 0)
            {
                sportPlan.DeleteSportPlan(id);
                userData.SportPlan = sportPlan.PostSportPlan(id, lvl + 1).Sport;
            }

            return View("Plan", userData);
        }
    }
}