using System.Web.Mvc;
using SciFit.Logic;
using SciFit.Models;

namespace SciFit.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModelMainView user)
        {
            if (ModelState.IsValid)
            {
                var mainView = new UserModelPartialView()
                {
                    User = user.User = new UserModel()
                    {
                        UserName = user.UserName,
                        Password = user.Password,
                        Email = user.Email
                    }
                };

                return View("RegisterUserPartial", mainView);
            }
            return View();
        }
        public ActionResult RegisterValidation(UserModel partialView)
        {
            var mainView = new UserModelPartialView()
            {
                User = partialView
            };

            return View("RegisterUserPartial", mainView);
        }
    }
}