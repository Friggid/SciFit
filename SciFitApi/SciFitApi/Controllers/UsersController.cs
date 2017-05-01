using System.Linq;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using SciFitApi.Models;

namespace SciFitApi.Controllers
{
    public class UsersController : ApiController
    {
        private readonly SciFitApiContext _db = new SciFitApiContext();

        //GET api/Users
        public IQueryable<UsersModel> GetUsers()
        {
            return _db.Users;
        }

        //GET api/Users/5
        [ResponseType(typeof(UsersModel))]
        public IHttpActionResult GetUser(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //PUT api/Users/5
        public IHttpActionResult PutUser(int id, UsersModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _db.Entry(user).State = EntityState.Modified;
            _db.Entry(user).Property(x => x.Password).IsModified = false;
            _db.SaveChanges();

            var user1 = _db.Users.Find(id);

            var password = (from x in _db.Users
                         where x.Id == id
                         select x.Password).ToString();

            user1.Password = password;
            return Ok(user1);
        }

        //POST api/User
        [ResponseType(typeof(UsersModel))]
        public IHttpActionResult PostUser(UsersModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var users = (from x in _db.Users
                         where x.UserName == user.UserName
                         select x).ToList();
            if (users.Count > 0)
            {
                return BadRequest("username");
            }
            users = (from x in _db.Users
                         where x.Email == user.Email
                         select x).ToList();
            if (users.Count > 0)
            {
                return BadRequest("email");
            }

            user.Password = HashPass(user.Password);

            _db.Entry(user).State = EntityState.Added;

            _db.SaveChanges();

            return Ok(user);
        }

        public IHttpActionResult DeleteUser(int id)
        {
            var user = (from x in _db.Users
                        where x.Id == id
                        select x).SingleOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            _db.Entry(user).State = EntityState.Deleted;

            _db.SaveChanges();
            return Ok();
        }

        #region Private helpers
        private string HashPass(string pass)
        {
            var result = pass;
            using (var md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                var sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                result = sBuilder.ToString();
            }
            return result;
        }
        #endregion
    }
}