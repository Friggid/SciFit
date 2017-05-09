using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;
using System.Web;
using System.IO;

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
            var searchedUsers = (List<UserModel>)TempData["SearchedUsers"];

            ViewBag.UserNotFound = TempData["UserNotFound"];

            if (searchedUsers != null)
            {
                users.Users = searchedUsers;
                return View(users);
            }

            users.Users = usersLogic.GetUsers();

            return View(users);
        }

        public ActionResult ChangeTheme(string theme)
        {
            Session["CustomTheme"] = theme;

            return RedirectToAction("AdminPanel", "Administration");
        }

        public ActionResult AdministratePlans()
        {
            var plans = new AdministrationModel();
            var plansLogic = new PlanTemplate();

            plans.Plans = plansLogic.GetPlanTemplate();

            return View(plans);
        }

        [HttpPost]
        public ActionResult AdministrateUsersSearch(string searchKey)
        {
            var model = SearchPlan(searchKey);

            TempData["SearchedUsers"] = model;

            return RedirectToAction("AdminPanel", "Administration");
        }

        private List<UserModel> SearchPlan(string searchKey)
        {
            var users = new AdministrationModel();
            var usersLogic = new Users();
            var searchedUsers = new List<UserModel>();

            users.Users = usersLogic.GetUsers();

            foreach (var data in users.Users)
            {
                if (searchKey == "")
                {
                    searchedUsers = users.Users;
                }
                else
                {
                    if (data.UserName.Contains(searchKey) || data.Email.Contains(searchKey))
                    {
                        searchedUsers.Add(new UserModel()
                        {
                            Id = data.Id,
                            Email = data.Email,
                            Password = data.Password,
                            UserName = data.UserName,
                            RoleId = data.RoleId,
                            Age = data.Age,
                            Difficulty = data.Difficulty,
                            Weight = data.Weight,
                            Height = data.Height,
                            Name = data.Name,
                            Address = data.Address,
                            Surname = data.Surname
                        });
                    }
                }
            }

            if (searchedUsers.Count == 0 || searchedUsers == null)
            {
                TempData["UserNotFound"] = true;
            }

            return searchedUsers;
        }

        public ActionResult EditPlanSelected(int id)
        {
            var planTemplate = new PlanTemplate();
            var plan = planTemplate.GetPlanTemplateById(id);

            return View(plan);
        }

        public ActionResult CreatePlan()
        {
            return View();
        }

        public ActionResult AdministratePlansCreate(PlanTemplateModel model, HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (HasImageExtension(file.FileName))
                {
                    if (file.ContentLength > 0)
                    {
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            byte[] imageData = null;
                            imageData = binaryReader.ReadBytes(file.ContentLength);
                            model.ImgContent = imageData;
                        }
                    }
                }
            }

            var planTemplateLogic = new PlanTemplate();
            model.StartDate = DateTime.Now;
            var savedPlan = planTemplateLogic.PostPlanTemplate(model);

            if (savedPlan != null)
            {
                return RedirectToAction("AdministratePlans", "Administration");
            }

            return RedirectToAction("AdministratePlans", "Administration");
        }

        public ActionResult AdministratePlansSave(PlanTemplateModel model, HttpPostedFileBase file)
        {
            if (file != null)
            {
                if (HasImageExtension(file.FileName))
                {
                    if (file.ContentLength > 0)
                    {
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            byte[] imageData = null;
                            imageData = binaryReader.ReadBytes(file.ContentLength);
                            model.ImgContent = imageData;
                        }
                    }
                }
            }

            var planTemplate = new PlanTemplate();

            var savedPlan = planTemplate.PutPlanTemplate(model);

            if (savedPlan != null)
            {
                return RedirectToAction("AdministratePlans", "Administration");
            }

            return RedirectToAction("AdministratePlans", "Administration");
        }

        private bool HasImageExtension(string source)
        {
            return (source.EndsWith(".png") || source.EndsWith(".jpg"));
        }
        public ActionResult AdministratePlansDelete(int id)
        {
            var planTemplate = new PlanTemplate();
            planTemplate.DeletePlanTemplate(id);

            return RedirectToAction("AdministratePlans", "Administration");
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
    }
}