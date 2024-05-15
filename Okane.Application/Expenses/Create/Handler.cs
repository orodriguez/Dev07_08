using Okane.Domain;

namespace Okane.Application.Expenses.Create;

public class Handler
{
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public Response Handle(Request request)
    {
        var expense = new Expense
        {
            Amount = request.Amount,
            Category = request.Category,
            Description = request.Description
        };

        _expensesRepository.Add(expense);
        
        return new Response(expense.Id, request.Amount, request.Category, request.Description);
    }
}