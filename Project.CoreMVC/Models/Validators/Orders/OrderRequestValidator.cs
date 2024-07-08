using FluentValidation;
using Project.CoreMVC.Models.Orders.PureVMs;

namespace Project.CoreMVC.Models.Validators.Orders
{
    public class OrderRequestValidator : AbstractValidator<OrderViewModel>
    {
        public OrderRequestValidator()
        {
            RuleFor(x => x.ShippingAddress).NotNull().WithMessage("Shipping Address is required.");
            RuleFor(x => x.ShippingAddress).MinimumLength(20).WithMessage("Shipping Address must be at least 20 characters.");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Please write your email!");
            RuleFor(x => x.Email).NotNull().WithMessage("Email field is required!");

            RuleFor(x => x.NameDescription).NotNull().WithMessage("Name description is required.");
        }
    }
}
