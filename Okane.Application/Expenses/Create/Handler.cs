using FluentValidation;
using Okane.Application.Common.Responses;
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

    public IResponse Handle(Request request)
    {
        var validation = _validator.Validate(request);

        if (!validation.IsValid)
            return ValidationErrorsResponse.From(validation);
        
        var expense = new Expense
        {
            Amount = request.Amount,
            Category = request.Category
        };

        _expensesRepository.Add(expense);
        
        return new Response(expense.Id, request.Amount, request.Category);
    }
}