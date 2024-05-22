namespace Okane.Application.Expenses.CategoryID;

public class GetExpensesByCategoryID
{
    private readonly IExpensesRepository _expensesRepository;

    public GetExpensesByCategoryID(IExpensesRepository expensesRepository) =>
        
        _expensesRepository = expensesRepository;

    public IEnumerable<ExpenseResponse> Handle(int categoryId) =>
        
        _expensesRepository
            .All()
            .Where(expense => expense.Category.Id == categoryId)
            .Select(expense => expense.ToExpenseResponse());
}