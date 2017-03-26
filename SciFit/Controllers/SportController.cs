using System.Web.Mvc;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class SportController : Controller
    {
        public ActionResult SportPlan(User user)
        {
            //TODO username ir pass patikrinimas
            //if(ok) aiti i  View("SportPlanPartial")
            //else View("Login")

            return View("SportPlanPartial");
        }
    }
}