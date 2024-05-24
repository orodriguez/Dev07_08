using Okane.Application.Auth;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.ById;

public class GetExpenseByIdHandler
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly IUserSession _userSession;

    public GetExpenseByIdHandler(IExpensesRepository expensesRepository, IUserSession userSession)
    {
        _expensesRepository = expensesRepository;
        _userSession = userSession;
    }

    public IResponse Handle(int id)
    {
        var expense = _expensesRepository
            .All()
            .Where(e => e.Id == id && e.UserId == _userSession.GetCurrentUserId()).FirstOrDefault();

        if (expense == null)
            return new NotFoundResponse();
        
        return expense.ToExpenseResponse();
    }
}