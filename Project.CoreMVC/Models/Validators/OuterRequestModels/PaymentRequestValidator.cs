using FluentValidation;
using Project.CoreMVC.Models.OuterRequestModel;

namespace Project.CoreMVC.Models.Validators.OuterRequestModels
{
    public class PaymentRequestValidator : AbstractValidator<PaymentRequestModel>
    {
        public PaymentRequestValidator()
        {
            RuleFor(x => x.CardNumber).NotEmpty().WithMessage("Card number cannot be empty.")
                                      .MinimumLength(19).WithMessage("Card number must be 19 characters long.").MaximumLength(19).WithMessage("Card number must be 19 characters long")
                                      .CreditCard().WithMessage("Please enter a valid credit card number.");

            RuleFor(x => x.CardUserName).NotNull().WithMessage("Card UserName is required.");

            RuleFor(x => x.CCV).NotEmpty().WithMessage("CCV cannot be empty.")
                                      .MinimumLength(3).WithMessage("Card number must be 3 or 4 characters long.").MaximumLength(4).WithMessage("Card number must be 3 or 4 characters long");

            RuleFor(x => x.ExpiryYear).NotEmpty().WithMessage("Expiry year cannot be empty.").InclusiveBetween(2024, 2050).WithMessage("Expiry year must be between 2014 and 2050.");

            RuleFor(x => x.ExpiryMonth).NotEmpty().WithMessage("Expiry month cannot be empty!").InclusiveBetween(1, 12).WithMessage("Expiry month must be between 1 and 12.");

        }
    }
}
