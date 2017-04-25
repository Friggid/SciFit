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
    }
}