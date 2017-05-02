using System.ComponentModel.DataAnnotations;

namespace SciFit.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email format is incorrect!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between 3 and 20 characters!")]
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string Age { get; set; }
        
        public string Weight { get; set; }

        public string Height { get; set; }

        public string Difficulty { get; set; }
    }
}