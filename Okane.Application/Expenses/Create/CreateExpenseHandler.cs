using FluentValidation;
using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public class CreateExpenseHandler
{
    private readonly IValidator<CreateExpenseRequest> _validator;
    private readonly IExpensesRepository _expensesRepository;
    private readonly Func<DateTime> _now;

    public CreateExpenseHandler(
        IValidator<CreateExpenseRequest> validator, 
        IExpensesRepository expensesRepository, 
        Func<DateTime> now)
    {
        _validator = validator;
        _expensesRepository = expensesRepository;
        _now = now;
    }

    public IExpenseResponse Handle(CreateExpenseRequest createExpenseRequest)
    {
        var validation = _validator.Validate(createExpenseRequest);

        if (!validation.IsValid)
            return ValidationErrorsResponse.From(validation);
        
        var expense = createExpenseRequest.ToExpense(_now());

        _expensesRepository.Add(expense);
        
        return expense.ToExpenseResponse();
    }
}