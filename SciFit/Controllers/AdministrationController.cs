using System;
using System.Linq;
using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class AdministrationController : Controller
    {
        public ActionResult Logout()
        {
            Session["UserData"] = null;
            return RedirectToAction("Login", "Authentication");
        }

        public ActionResult AdminPanel()
        {
            var users = new AdministrationModel();
            var usersLogic = new Users();

            users.Users = usersLogic.GetUsers();

            return View(users);
        }

        public ActionResult AdministrateUserProfile(int id)
        {
            var user = new Users();
            var model = user.GetUser(id);

            return View(model);
        }

        public ActionResult AdministrateUserProfileSave(UserModel model)
        {
            var user = new Users();
            var savedUser = user.PutUser(model.Id, model);

            if (savedUser != null)
            {
                return RedirectToAction("AdminPanel", "Administration");
            }

            return RedirectToAction("AdministrateUserProfile", "Administration", model.Id);
        }

        public ActionResult AdministrateUserProfileDelete(int id)
        {
            var user = new Users();
            var userDeleted = user.DeleteUser(id);

            if (userDeleted)
            {
                return RedirectToAction("AdminPanel", "Administration");
            }

            return RedirectToAction("AdminPanel", "Administration");
        }

        public ActionResult UserProfile(int id, string pass)
        {
            var user = new Users();
            var model = user.GetUser(id);
            var viewModel = new UserProfileViewModel
            {
                Id = model.Id,
                RoleId = model.RoleId,
                Name = model.Name,
                Surname = model.Surname,
                Address = model.Address,
                Email = model.Email,
                UserName = model.UserName,
                Password = pass,
                Age = model.Age,
                Weight = model.Weight,
                Height = model.Height,
                Difficulty = model.Difficulty
            };
            model.Password = pass;
            return View(viewModel);
        }

        public ActionResult CreatePlan(int id, string pass)
        {
            var model = new PlanTemplateModel();
            model.Id = id;
            ViewBag.Id = id;
            ViewBag.Pass = pass;
            return View(model);
        }

        public ActionResult EditPlan(int id, string pass)
        {
            var temp = new PlanTemplate();
            var allTemp = temp.GetPlanTemplate();
            ViewBag.Id = id;
            ViewBag.Pass = pass;
            return View(allTemp);
        }

        public ActionResult UserProfileSave(UserProfileViewModel model)
        {
            var user = new Users();
            var generatePlan = new GeneratePlan();

            var pass = model.Password;
            var newModel = new UserModel
            {
                Id = model.Id,
                RoleId = model.RoleId,
                Name = model.Name,
                Surname = model.Surname,
                Address = model.Address,
                Email = model.Email,
                UserName = model.UserName,
                Age = model.Age,
                Weight = model.Weight,
                Height = model.Height,
                Difficulty = model.Difficulty
            };
            newModel.Password = null;

            if (user.PutUser(model.Id, newModel) != null)
            {
                newModel.Password = pass;

                var sportPlan = new SportPlan();
                var sports = sportPlan.GetSportPlanById(newModel.Id);

                var level = 1;
                foreach (var item in sports.Sport)
                {
                    level = item.Level;
                }
                sportPlan.DeleteSportPlan(newModel.Id);
                var sport = sportPlan.PostSportPlan(newModel.Id, level);

                var userData = new SportNutritionPlanModel
                {
                    SportPlan = sport.Sport,
                    NutritionPlan = generatePlan.GenerateNutritionPlan(newModel),
                    User = newModel
                };

                return View("../Sport/Plan", userData);
            }
            return RedirectToAction("UserProfile", "Administration", model.Id);
        }

        public ActionResult CreatePlanCreate(PlanTemplateModel model)
        {
            int userId = model.Id;
            model.Id = 0;

            var modelData = new PlanTemplateModel();
            modelData.Id = userId;
            ViewBag.Id = userId;
            return View("CreatePlan", modelData);
        }

        public ActionResult CreatePlanCancel(int id, string pass)
        {
            var user = new Users();
            var userGet = user.GetUser(id);
            userGet.Password = pass;
            return RedirectToAction("Login", "Sport", userGet);
        }

        public ActionResult EditPlanSelected(int id, int userId, string pass)
        {
            var temp = new PlanTemplate();
            var tempGet = temp.GetPlanTemplateById(id);
            var model = new TemplateViewModel
            {
                Id = tempGet.Id,
                Name = tempGet.Name,
                Reps = tempGet.Reps,
                Image = tempGet.Image,
                Instructions = tempGet.Instructions,
                Level = tempGet.Level,
                Done = tempGet.Done,
                UserId = userId,
                Pass = pass
            };
            ViewBag.Id = userId;
            ViewBag.Pass = pass;
            return View(model);
        }

        public ActionResult SelectedPlanChanged(TemplateViewModel model)
        {
            var temp = new PlanTemplate();
            var allTemp = temp.GetPlanTemplate();

            ViewBag.Id = model.UserId;

            return View("EditPlan", allTemp);
        }
    }
}