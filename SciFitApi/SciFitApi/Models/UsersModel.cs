using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFitApi.Models
{
    public class UsersModel
    {
        //public UsersModel()
        //{
        //    Plan = new List<PlanModel>();
        //}

        public int Id { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        //navigate
        //public virtual RolesModel Roles { get; set; }

        //public virtual ICollection<PlanModel> Plan { get; set; }

    }
}