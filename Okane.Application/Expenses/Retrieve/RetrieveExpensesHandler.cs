using Okane.Application.Auth;

namespace Okane.Application.Expenses.Retrieve;

public class RetrieveExpensesHandler
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly IUserSession _userSession;

    public RetrieveExpensesHandler(IExpensesRepository expensesRepository, IUserSession userSession)
    {
        _expensesRepository = expensesRepository;
        _userSession = userSession;
    }

    public IEnumerable<ExpenseResponse> Handle()
    {
        var userId = _userSession.GetCurrentUserId();

        var expenses = _expensesRepository
            .All()
            .Where(e => e.UserId == userId)
            .Select(expense => expense.ToExpenseResponse());

        return expenses;
    }
}