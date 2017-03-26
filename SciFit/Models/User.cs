using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SciFit.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Weight { get; set; }
        public string Difficulty { get; set; }
    }
}