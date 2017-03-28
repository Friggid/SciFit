using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SciFitApi.Models
{
    public class SciFitApiContextInitializer : DropCreateDatabaseAlways<SciFitApiContext>
    {
        protected override void Seed(SciFitApiContext context)
        {
            var roles = new List<RolesModel>
            {
                new RolesModel
                {
                    Title = "User"
                },
                new RolesModel
                {
                    Title = "Admin"
                }
            };
            roles.ForEach(x => context.Roles.Add(x));
            context.SaveChanges();

            var users = new List<UsersModel>
            {
                new UsersModel
                {
                    RoleId = 1,
                    Name = "Lukas",
                    Surname = "Ignatavicius",
                    Address = "Virsuliskes",
                    Email = "lukas@gmail.com"
                }
            };
            users.ForEach(x => context.Users.Add(x));
            context.SaveChanges();

            var plan = new List<PlanModel>
            {
                new PlanModel
                {
                    UserId = 0,
                    Title = "My first plan",
                    Author = "A name of author",
                    StartDate = "2016"
                }
            };
            plan.ForEach(x => context.Plan.Add(x));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}