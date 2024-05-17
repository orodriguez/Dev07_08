using Okane.Domain;

namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public UpdateExpenseHandler(IExpensesRepository expensesRepository)
    {
        _expensesRepository = expensesRepository;
    } 

    public IExpenseResponse Handle(UpdateExpenseRequest updateExpenseRequest)
    {
        var updatingExpense = _expensesRepository.ById(updateExpenseRequest.Id);

        if (updatingExpense == null)
            return new NotFoundResponse();
        
        updateExpenseRequest.ToExpense(updatingExpense);
        
        _expensesRepository.Update(updatingExpense);

        return updatingExpense.ToExpenseResponse();
    }
}