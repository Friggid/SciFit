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

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ValidateUsername(user.UserName) && user.Password != null && user.Email != null)
            {
                return View("RegisterUserPartial", user);
            }
            return View();
        }

        public bool ValidateUsername(string username)
        {
            if (username != null)
            {
                return true;
            }
            return false;
        }
    }
}