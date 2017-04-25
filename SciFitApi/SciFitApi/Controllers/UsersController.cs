using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SciFitApi.Models;

namespace SciFitApi.Controllers
{
    public class UsersController : ApiController
    {
        private SciFitApiContext _db = new SciFitApiContext();

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

            _db.SaveChanges();
           
            return Ok(user);
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

            _db.Entry(user).State = EntityState.Added;

            _db.SaveChanges();

            return Ok(user);
        }
    }
}