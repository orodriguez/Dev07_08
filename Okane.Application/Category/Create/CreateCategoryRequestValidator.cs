using FluentValidation;

namespace Okane.Application.Category.Create
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(request => request.Name)
                .NotEmpty()
                .WithMessage("The category name must not be empty.")
                .MaximumLength(50)
                .WithMessage("The category name must not exceed 50 characters.");
        }
    }
}