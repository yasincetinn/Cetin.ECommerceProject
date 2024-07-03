using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.AppUsers
{
    public class UserSignInModel
    {
        [Required(ErrorMessage = "{0} field is required")]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} field is required")]
        [MinLength(3, ErrorMessage = "Minimum {1} characters must be entered")]
        public string Password { get; set; }


    }
}
