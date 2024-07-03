using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.AppUsers
{
    public class ResetPasswordModel
    {

        [Required(ErrorMessage = "{0} field is required")]
        [MinLength(3, ErrorMessage = "Minimum {1} characters must be entered")]
        public string NewPassword { get; set; }


        [Compare("NewPassword", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

    }
}
