using FluentValidation;

namespace Okane.Application.Categories.Create;

public class Validator : AbstractValidator<CreateCategoryRequest>
{
    public Validator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name cannot be longer than 100 characters.");
    }
}