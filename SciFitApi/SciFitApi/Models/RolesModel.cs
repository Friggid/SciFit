using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFitApi.Models
{
    public class RolesModel
    {
        //public RolesModel()
        //{
        //    Users = new List<UsersModel>();
        //}

        public int Id { get; set; }

        public string Title { get; set; }

        //navigation
        //public virtual ICollection<UsersModel> Users { get; set; }
    }
}