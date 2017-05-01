using System.Dynamic;
using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class SportController : Controller
    {
        public ActionResult SportPlan(UserModelPartialView userModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("RegisterValidation", "Authentication", userModel.User);
            }

            //Hardcoded for normal user
            userModel.User.RoleId = 1;
            userModel.User.Age = userModel.Age;
            userModel.User.Weight = userModel.Weight;
            userModel.User.Height = userModel.Height;
            userModel.User.Difficulty = userModel.Difficulty;

            var users = new Users();

            if (!users.PostUser(userModel.User))
            {
                return RedirectToAction("Register", "Authentication");
            }
            return RedirectToAction("Login", "Authentication");
        }

        public ActionResult Plan()
        {
            var model = Session["UserData"];
            return View(model);
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
                ViewBag.Id = userData.User.Id;

                Session["UserData"] = userData;

                if (userData.User.RoleId == 2)
                {
                    return RedirectToAction("AdminPanel", "Administration");
                }
                return RedirectToAction("Plan", "Sport");
            }

            TempData["badPassword"] = "Username/Password is incorrect!";
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

        public ActionResult Statistics()
        {
            var model = (SportNutritionPlanModel)Session["UserData"];

            var statisticsLogic = new Statistics();
            var statisticsModel = statisticsLogic.GetStatisticsById(model.User.Id);

            if (statisticsModel != null)
            {
                return View(statisticsModel);
            }

            return RedirectToAction("Plan", "Sport");
        }
    }
}