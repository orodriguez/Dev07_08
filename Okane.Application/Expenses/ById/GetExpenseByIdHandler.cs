namespace Okane.Application.Expenses.ById;

public class GetExpenseByIdHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public GetExpenseByIdHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IExpenseResponse Handle(int id)
    {
        var expense = _expensesRepository
            .ById(id);

        if (expense == null)
            return new NotFoundResponseExpenses();
        
        return expense.ToExpenseResponse();
    }
}