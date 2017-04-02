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
        private SciFitApiContext db = new SciFitApiContext();

        //GET api/Users
        public IQueryable<UsersModel> GetUsers()
        {
            return db.Users;
        }

        //GET api/Users/5
        [ResponseType(typeof(UsersModel))]
        public IHttpActionResult GetUser(int id)
        {
            var user = db.Users.Find(id);
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

            db.Entry(user).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //TODO
                //if (!UserExists(id))
                //{
                //    return NotFound();
                //}
                throw;
            }
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

            db.Entry(user).State = EntityState.Added;

            db.SaveChanges();

            return Ok(user);
        }
    }
}