using System.ComponentModel.DataAnnotations;

namespace SciFit.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public int RoleId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public string Weight { get; set; }

        public string Height { get; set; }

        public string Difficulty { get; set; }
    }
}