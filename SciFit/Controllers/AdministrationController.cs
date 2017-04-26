using System.Web.Mvc;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class AdministrationController : Controller
    {
        public ActionResult MainPanel(int roleId)
        {
            ViewBag.RoleId = roleId;
            return View();
        }

        public ActionResult NavigateBackToProfile()
        {
            return RedirectToAction("SportPlan", "Sport");
        }

        public ActionResult AdminPartial()
        {
            return View();
        }

        public ActionResult AdmininstratePlan()
        {
            return PartialView("AdminPlansPartial");
        }

        public ActionResult UserProfile(UserModel model)
        {
            return View(model);
        }

        public ActionResult CreatePlan()
        {
            return View();
        }

        public ActionResult EditPlan()
        {
            return View();
        }

        public ActionResult UserProfileSave()
        {
            return View();
        }

    }
}