namespace Okane.Application.Expenses.Retrieve;

public class Handler
{
    private readonly IExpensesRepository _expensesRepository;

    public Handler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IEnumerable<Response> Handle()
    {
        var expenses = _expensesRepository.All();
        var response = expenses
            .Select(expense => new Response(expense.Id, expense.Amount, expense.Category, expense.Description));
        return response;
    }

    public IEnumerable<Response> HandleById(string id)
    {
        var expenses = _expensesRepository.All();
        var response = expenses
            .Select(expense => new Response(expense.Id, expense.Amount, expense.Category, expense.Description))
            .Where(expense => expense.Id == int.Parse(id));
        return response;
    }
}