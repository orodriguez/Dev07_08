using MediatR;
using Okane.Application.Auth;

namespace Okane.Application.Expenses.Retrieve;

public class RetrieveExpensesHandler : IRequestHandler<RetrieveExpensesRequest, RetrieveExpensesResponse>
{
    private readonly IReadOnlyExpensesRepository _expensesRepository;
    private readonly IUserSession _session;

    public RetrieveExpensesHandler(IReadOnlyExpensesRepository expensesRepository, IUserSession session)
    {
        _expensesRepository = expensesRepository;
        _session = session;
    }

    public Task<RetrieveExpensesResponse> Handle(RetrieveExpensesRequest request, CancellationToken cancellationToken)
    {
        var userId = _session.CurrentUserId;

        var expenses = _expensesRepository
            .ByUserId(userId)
            .Select(expense => expense.ToExpenseResponse());
        
        return Task.FromResult(new RetrieveExpensesResponse(expenses));
    }
}