using FluentValidation;

namespace Okane.Application.Category.Create
{
    // Check
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(request => request.Category)
                .NotEmpty()
                .WithMessage($"{nameof(CreateCategoryRequest.Category)}The category name must not be empty.")
                .MaximumLength(50)
                .WithMessage($"{nameof(CreateCategoryRequest.Category)} Is too big");
        }
    }
}