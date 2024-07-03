using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.AppUsers
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "{0} field is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [MinLength(3, ErrorMessage = "Minimum {0} characters must be entered")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

    }
}
