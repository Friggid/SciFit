using System.Web.Mvc;

namespace SciFit.Controllers
{
    //komentaras
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["CustomTheme"] == null)
            {
                Session["CustomTheme"] = "~/Content/default-theme";
            }
            return View();
        }

        public ActionResult ChangeTheme(string theme)
        {
            Session["CustomTheme"] = theme;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Program()
        {
            return View();
        }
    }
}