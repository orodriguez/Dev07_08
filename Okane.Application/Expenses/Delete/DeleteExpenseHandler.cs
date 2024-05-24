using MediatR;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.Delete;

public class DeleteExpenseHandler : IRequestHandler<DeleteExpenseRequest, IDeleteExpenseResponse>
{
    private readonly IExpensesRepository _expenses;

    public DeleteExpenseHandler(IExpensesRepository expenses) => 
        _expenses = expenses;

    public Task<IDeleteExpenseResponse> Handle(DeleteExpenseRequest request, CancellationToken cancellationToken)
    {
        var expenseToDelete = _expenses.ById(request.Id);

        if (expenseToDelete == null)
            return Task.FromResult<IDeleteExpenseResponse>(new NotFoundResponse());

        _expenses.Delete(expenseToDelete);

        return Task.FromResult<IDeleteExpenseResponse>(expenseToDelete.ToExpenseResponse());
    }
}