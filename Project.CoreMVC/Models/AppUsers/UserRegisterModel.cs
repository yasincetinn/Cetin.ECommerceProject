using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.AppUsers
{
    public class UserRegisterModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
