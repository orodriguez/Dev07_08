using Okane.Domain;

namespace Okane.Application.Expenses.Retrieve;

public class Handler
{
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IEnumerable<Response> Handle() =>
        _expensesRepository
            .All()
            .Select(expense => expense.ToExpenseResponse());
}