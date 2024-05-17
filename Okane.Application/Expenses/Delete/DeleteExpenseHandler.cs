using Okane.Domain;

namespace Okane.Application.Expenses.Delete;

public class DeleteExpenseHandler
{
    private readonly IExpensesRepository _expensesRepository;

    public DeleteExpenseHandler(IExpensesRepository expensesRepository)
    {
        _expensesRepository = expensesRepository;
    } 

    public IExpenseResponse Handle(int id)
    {
        var toDelete = _expensesRepository.ById(id);

        if (toDelete == null)
            return new NotFoundResponse();
        
        _expensesRepository.Delete(id);

        return toDelete.ToExpenseResponse();
    }
}