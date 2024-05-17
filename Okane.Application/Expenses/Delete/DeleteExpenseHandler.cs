namespace Okane.Application.Expenses.Delete;

public class DeleteExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public DeleteExpenseHandler(IExpensesRepository expensesRepository) =>
        _expensesRepository = expensesRepository;

    public IExpenseResponse Handle(int id)
    {
        var deletedExpense = _expensesRepository.Delete(id);
        
        if (deletedExpense is null)
            return new NotFoundResponse();
        return deletedExpense.ToExpenseResponse();
    }
}