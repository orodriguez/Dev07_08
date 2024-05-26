using FluentValidation;
using Okane.Application.Responses;

namespace Okane.Application.Budget.Create;

public class CreateBudgetHandler
{
    private readonly IBudgetRepository _budget;
    private readonly IValidator<CreateBudgetRequest> _validator;

    public CreateBudgetHandler(IBudgetRepository budget, IValidator<CreateBudgetRequest> validator) =>
        (_budget, _validator) = (budget, validator);

    public ICreateBudgetResponse Handle(CreateBudgetRequest request)
    {
        var result = _validator.Validate(request);

        if (!result.IsValid)
        {
            return ValidationErrorsResponse.From(result);
        }

        var existingBudget = _budget.GetByCategoryId(request.CategoryId);
        if (existingBudget != null)
        {
            return new ConflictResponse($"Budget for category ID '{request.CategoryId}' already exists.");
        }

        var budget = request.ToBudget();
        _budget.Add(budget);
        return BudgetResponse.From(budget);
    }
}