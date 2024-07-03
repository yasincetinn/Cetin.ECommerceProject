using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.AppUsers
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "{0} field is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
