﻿using System.ComponentModel.DataAnnotations;

namespace SciFit.Models
{
    public class UserModelPartialView
    {
        public string Age { get; set; }

        public string Weight { get; set; }

        public string Height { get; set; }

        public string Difficulty { get; set; }

        public UserModel User { get; set; }
    }
}
