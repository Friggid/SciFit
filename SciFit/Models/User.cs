using System;
using System.ComponentModel.DataAnnotations;

namespace SciFit.Models
{
    public partial class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public System.DateTime CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}