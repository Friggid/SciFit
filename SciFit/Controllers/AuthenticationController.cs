using System.Web.Mvc;
using SciFit.Logic;
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

        public ActionResult RegisterUser(UserModel user)
        {
            var users = new Users();

            //if (users.PostUser(user))
            //{
            //    return View("RegisterUserPartial", user);
            //}

            return View("RegisterUserPartial", user);
        }
    }
}