
namespace Okane.Application.Expenses.Retrieve;

public class Handler
{
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IExpensesRepository expensesRepository) =>
        _expensesRepository = expensesRepository;

    public IEnumerable<Response> HandleAll()
    {
        var expenses = _expensesRepository.All();
        var response = expenses
            .Select(expense => new Response(expense.Id, expense.Amount, expense.Category, expense.Description ));
        return response;
    }
    public Response HandleById(int id)
    {
        var expense = _expensesRepository.GetById(id);
        if (expense != null)
        {
            return new Response(expense.Id, expense.Amount, expense.Category, expense.Description);
        }
        else
        {
            return null; 
        }
    }
}
  
