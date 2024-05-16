namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public UpdateExpenseHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;
        // updateExpenseRequest
    public IExpenseResponse Handle(UpdateExpenseRequest updateExpenseRequest)
    {
        var existingExpense = _expensesRepository.ById(updateExpenseRequest.Id);

        if (existingExpense == null)
        {
            return new NotFoundResponse();
        }
        existingExpense.Amount = updateExpenseRequest.Amount;
        existingExpense.Category = updateExpenseRequest.Category;
        existingExpense.Description = updateExpenseRequest.Description;
        _expensesRepository.Update(existingExpense);
        return existingExpense.ToExpenseResponse();
        // Now its Implemented
    }
}