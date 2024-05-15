using Okane.Domain;

namespace Okane.Application.Expenses.ById;

public class Handler
{
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IExpenseResponse Handle(int id)
    {
        var expense = _expensesRepository
            .ById(id);

        if (expense == null)
            return new NotFoundResponse();
        
        return expense.ToExpenseResponse();
    }
}