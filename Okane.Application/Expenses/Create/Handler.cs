using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public class Handler
{
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public SuccessResponse Handle(Request request)
    {
        var expense = request.ToExpense();

        _expensesRepository.Add(expense);
        
        return expense.ToExpenseResponse();
    }
}