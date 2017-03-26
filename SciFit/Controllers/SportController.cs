using System.Web.Mvc;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class SportController : Controller
    {
        public ActionResult SportPlan(User user)
        {
            return View("Plan");
        }
    }
}