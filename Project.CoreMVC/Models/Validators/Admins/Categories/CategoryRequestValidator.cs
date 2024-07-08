using FluentValidation;
using Project.CoreMVC.Areas.Admin.Models.Categories.PureVMs;

namespace Project.CoreMVC.Models.Validators.Admins.Categories
{
    public class CategoryRequestValidator : AbstractValidator<CategoryRequestModel>
    {
        public CategoryRequestValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category name is required!").MaximumLength(50).WithMessage("Category name must be less than 50 characters");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Category description name is required!");
        }
    }
}
