using System.Web.Mvc;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult RegisterUser(User user)
        {
            return View("RegisterUserPartial", user);
        }

        public ActionResult GetUserData(User user)
        {
            return View("Login");
        }
    }
}