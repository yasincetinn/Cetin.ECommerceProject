using FluentValidation;
using Project.CoreMVC.Models.AppUsers;

namespace Project.CoreMVC.Models.Validators.AppUsers
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please write your email!");
            RuleFor(x => x.Email).NotNull().WithMessage("Email field is required!");    

        }
    }
}
