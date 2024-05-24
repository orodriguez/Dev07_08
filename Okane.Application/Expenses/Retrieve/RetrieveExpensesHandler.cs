using Okane.Application.Auth;

namespace Okane.Application.Expenses.Retrieve;

public class RetrieveExpensesHandler
{
    private readonly IReadOnlyExpensesRepository _expensesRepository;
    private readonly IUserSession _session;

    public RetrieveExpensesHandler(IReadOnlyExpensesRepository expensesRepository, IUserSession session)
    {
        _expensesRepository = expensesRepository;
        _session = session;
    }

    public IEnumerable<ExpenseResponse> Handle()
    {
        var userId = _session.CurrentUserId;
        
        return _expensesRepository
            .ByUserId(userId)
            .Select(expense => expense.ToExpenseResponse());
    }
}