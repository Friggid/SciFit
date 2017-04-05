﻿namespace SciFit.Models
{
    public class SportModel
    {
        public int Id { get; set; }

        public int SportPlanId { get; set; }

        public string Name { get; set; }

        public string Reps { get; set; }

        public string Image { get; set; }

        public string Instructions { get; set; }

        public int Level { get; set; }

        public int Done { get; set; }
    }
}