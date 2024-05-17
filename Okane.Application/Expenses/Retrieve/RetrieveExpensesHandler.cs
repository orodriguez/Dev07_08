namespace Okane.Application.Expenses.Retrieve;

public class RetrieveExpensesHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public RetrieveExpensesHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IEnumerable<ExpenseResponse> Handle() =>
        _expensesRepository
            .All()
            .Select(expense => expense.ToExpenseResponse());
}