using FluentValidation;
using Project.CoreMVC.Models.AppUsers;

namespace Project.CoreMVC.Models.Validators.AppUsers
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please write your email!");
            RuleFor(x => x.Email).NotNull().WithMessage("Email field is required!");

            RuleFor(x => x.UserName).NotNull().WithMessage("UserName field is required");

            RuleFor(x => x.Password).NotNull().WithMessage("Password field is required!");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Minimum 3 characters must be entered!");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords don't match!");
        }
    }
}
