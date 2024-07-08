using System.ComponentModel.DataAnnotations;

namespace Project.CoreMVC.Models.AppUsers
{
    public class UserSignInModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
