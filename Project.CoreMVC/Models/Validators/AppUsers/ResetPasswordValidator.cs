using FluentValidation;
using Project.CoreMVC.Models.AppUsers;

namespace Project.CoreMVC.Models.Validators.AppUsers
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordModel>
    {
        public ResetPasswordValidator()
        {
            RuleFor(x => x.NewPassword).NotNull().WithMessage("Password field is required!");
            RuleFor(x => x.NewPassword).MinimumLength(3).WithMessage("Minimum 3 characters must be entered!");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword).WithMessage("Passwords don't match!");
        }
    }
}
