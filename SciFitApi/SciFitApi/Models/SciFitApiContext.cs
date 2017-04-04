using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace SciFitApi.Models
{
    public class SciFitApiContext : DbContext
    {
        public SciFitApiContext() : base("name=SciFitApiContext")
        {
            
        }

        public DbSet<UsersModel> Users { get; set; }

        public DbSet<RolesModel> Roles { get; set; }

        public DbSet<PlanModel> Plan { get; set; }

        public DbSet<SportTemplateModel> SportTemplate { get; set; }

        public DbSet<SportModel> Sport { get; set; }

        public DbSet<SportPlanModel> SportCollection { get; set; }
    }
}