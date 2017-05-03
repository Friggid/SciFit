using System.ComponentModel.DataAnnotations;
﻿using System.Collections.Generic;
using System.Web;

namespace SciFit.Models
{
    public class PlanTemplateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between 3 and 20 characters!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Reps are required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between 3 and 20 characters!")]
        public string Reps { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Instructions are required!")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Must be between 3 and 255 characters!")]
        public string Instructions { get; set; }

        [Required(ErrorMessage = "Level is required!")]
        public int? Level { get; set; }

        public bool Done { get; set; }

        public byte[] ImgContent { get; set; }
    }
}