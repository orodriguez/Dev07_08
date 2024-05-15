using FluentValidation;

namespace Okane.Application.Expenses.Create;

public class Validator : AbstractValidator<Request>
{
    public Validator()
    {
        RuleFor(expense => expense.Amount).GreaterThan(0);
    }
}