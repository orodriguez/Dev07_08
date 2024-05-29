using FluentResults;
using MediatR;

namespace Okane.Application.Expenses.Create;

public class CreateExpenseHandler 
    : IRequestHandler<Request, Result<Response>>
{
    private readonly ExpenseFactory _expenseFactory;
    private readonly IExpensesRepository _expensesRepository;

    public CreateExpenseHandler(
        ExpenseFactory expenseFactory, 
        IExpensesRepository expensesRepository)
    {
        _expenseFactory = expenseFactory;
        _expensesRepository = expensesRepository;
    }
    
    public Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var result = _expenseFactory.Create(request);

        if (result.IsFailed)
            return Task.FromResult(Result.Fail<Response>(result.Errors));
        
        var expense = result.Value;
        
        _expensesRepository.Add(expense);
        
        return Task.FromResult(Result.Ok(expense.ToExpenseResponse()));
    }
}