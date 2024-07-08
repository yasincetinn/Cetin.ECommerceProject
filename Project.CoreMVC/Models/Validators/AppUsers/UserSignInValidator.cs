using FluentValidation;
using Project.CoreMVC.Models.AppUsers;

namespace Project.CoreMVC.Models.Validators.AppUsers
{
    public class UserSignInValidator : AbstractValidator<UserSignInModel>
    {
        public UserSignInValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("UserName field is required");

            RuleFor(x => x.Password).NotNull().WithMessage("Password field is required!");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Minimum 3 characters must be entered!");
        }
    }
}
