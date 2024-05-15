using Okane.Domain;

namespace Okane.Application.Expenses.ById;

public class Handler
{
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public Response Handle(int id) => 
        _expensesRepository
            .ById(id)
            .ToExpenseResponse();
}