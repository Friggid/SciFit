using System.ComponentModel.DataAnnotations;

namespace SciFit.Models
{
    public class UserModelMainView
    {
        [Required(ErrorMessage = "Email is required!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between 3 and 20 characters!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters!", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required!")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password, ErrorMessage = "Passwords must match")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public UserModel User { get; set; }
    }

}
