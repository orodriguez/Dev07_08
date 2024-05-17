using Okane.Domain;

namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public UpdateExpenseHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public IExpenseResponse Handle(int id, UpdateExpenseRequest request)
    {
        var expense = _expensesRepository.Update(id, request);

        if (expense == null)
            return new NotFoundResponse();
        
        return expense.ToExpenseResponse();
    }
}