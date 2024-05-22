using Okane.Application.Responses;

namespace Okane.Application.Expenses.Delete;

public class DeleteExpenseHandler
{
    private readonly IExpensesRepository _expenses;

    public DeleteExpenseHandler(IExpensesRepository expenses) => 
        _expenses = expenses;

    public IResponse Handle(int id)
    {
        var expenseToDelete = _expenses.ById(id);

        if (expenseToDelete == null)
            return new NotFoundResponse();

        _expenses.Delete(expenseToDelete);

        return expenseToDelete.ToExpenseResponse();
    }
}