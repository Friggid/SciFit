using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SciFitApi.Models;

namespace SciFitApi.Controllers
{
    public class LoginUserController : ApiController
    {
        private readonly SciFitApiContext _db = new SciFitApiContext();

        //POST api/User
        [ResponseType(typeof(UsersModel))]
        public IHttpActionResult PostUser(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = (from x in _db.Users
                          where x.UserName == username && x.Password == password
                          select x.Id).FirstOrDefault();

            var user = _db.Users.Find(userId);
            if (user != null)
            {
                return Ok(user);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}