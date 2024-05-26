using FluentValidation;

namespace Okane.Application.Budget.Create;

public class BudgetValidator : AbstractValidator<CreateBudgetRequest>
{
    public BudgetValidator()
    {
        RuleFor(x => x.CategoryId).GreaterThan(0);
        RuleFor(x => x.Maximum).GreaterThan(0);
    }
}