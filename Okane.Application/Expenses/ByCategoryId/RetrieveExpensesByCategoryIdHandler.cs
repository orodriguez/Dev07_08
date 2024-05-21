namespace Okane.Application.Expenses.ByCategoryId;

public class RetrieveExpensesByCategoryIdHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public RetrieveExpensesByCategoryIdHandler(IExpensesRepository expensesRepository) =>
        _expensesRepository = expensesRepository;

    public IEnumerable<ExpenseResponse> Handle(int categoryId) =>
        _expensesRepository
            .All()
            .Where(expense => expense.Category.Id == categoryId)
            .Select(expense => expense.ToExpenseResponse());
}
