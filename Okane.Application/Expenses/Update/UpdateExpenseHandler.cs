using Okane.Application.Expenses.Create;
using Okane.Domain;

namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public UpdateExpenseHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IExpenseResponse Handle(UpdateExpenseRequest updateExpenseRequest)
    {
        var expense = _expensesRepository
            .ById(updateExpenseRequest.Id);
        if (expense == null)
            return new NotFoundResponse();
        else
            _expensesRepository.Update(updateExpenseRequest.ToExpense());
        
        return updateExpenseRequest.ToExpense().ToExpenseResponse();
    }
}