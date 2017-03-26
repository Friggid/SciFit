using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFitApi.Models
{
    public class PlanModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string StartDate { get; set; }

        //navigate
        public virtual UsersModel User { get; set; }
    }
}