using FluentValidation;

namespace Okane.Application.Expenses.Create;

public class Validator : AbstractValidator<CreateExpenseRequest>
{
    public Validator()
    {
        RuleFor(request => request.Amount)
            .GreaterThan(-1)
            .WithMessage("Amount must be a positive value");

        RuleFor(request => request.Description)
            .MaximumLength(140)
            .WithMessage($"{nameof(CreateExpenseRequest.Description)} is too big");
        
        RuleFor(request => request.CategoryName)
            .MaximumLength(50)
            .WithMessage($"{nameof(CreateExpenseRequest.CategoryName)} is too big");
    }
}