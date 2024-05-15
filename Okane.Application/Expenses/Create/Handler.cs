using FluentValidation;
using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public class Handler
{
    private readonly IValidator<Request> _validator;
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IValidator<Request> validator, IExpensesRepository expensesRepository)
    {
        _validator = validator;
        _expensesRepository = expensesRepository;
    }

    public IExpenseResponse Handle(Request request)
    {
        var validation = _validator.Validate(request);

        if (!validation.IsValid)
            return ValidationErrorsResponse.From(validation);
        
        var expense = request.ToExpense();

        _expensesRepository.Add(expense);
        
        return expense.ToExpenseResponse();
    }
}