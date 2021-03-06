﻿namespace SciFit.Models
{
    public class TemplateViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Reps { get; set; }

        public string Image { get; set; }

        public string Instructions { get; set; }

        public int? Level { get; set; }

        public bool Done { get; set; }

        public int UserId { get; set; }

        public string Pass { get; set; }
    }
}