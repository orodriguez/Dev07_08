using FluentValidation;

namespace Okane.Application.Category.Create;

public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
{
    
    public CreateCategoryRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("The category name must not be empty.");
    }
}