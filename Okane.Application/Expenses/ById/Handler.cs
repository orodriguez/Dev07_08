namespace Okane.Application.Expenses.ById;

public class Handler
{
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public Response Handle(int id)
    {
        var expense = _expensesRepository.ById(id);
        
        // TODO: Extract method to create response
        return new Response(expense.Id, expense.Amount, expense.Category, expense.Description);
    }
}