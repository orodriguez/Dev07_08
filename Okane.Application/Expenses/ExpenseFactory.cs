using Okane.Application.Auth;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;
using Okane.Domain;

namespace Okane.Application.Expenses;

public class ExpenseFactory
{
    private readonly Func<DateTime> _now;
    private readonly IUserSession _session;

    public ExpenseFactory(Func<DateTime> now, IUserSession session)
    {
        _now = now;
        _session = session;
    }

    public Expense Create(CreateExpenseRequest request, Category category) =>
        new()
        {
            Amount = request.Amount,
            Category = category,
            Description = request.Description,
            UserId = _session.CurrentUserId,
            CreatedAt = _now()
        };
}