namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public UpdateExpenseHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IExpenseResponse Handle(UpdateExpenseRequest updateExpenseRequest)
    {
        throw new NotImplementedException();
    }
}