using FluentResults;
using MediatR;
using Okane.Application.Responses;
using Okane.Application.Results;
using Okane.Domain;

namespace Okane.Application.Expenses.Delete;

public class DeleteExpenseHandler : IRequestHandler<DeleteExpenseRequest, Result<ExpenseResponse>>
{
    private readonly IExpensesRepository _expenses;

    public DeleteExpenseHandler(IExpensesRepository expenses) => 
        _expenses = expenses;

    public Task<Result<ExpenseResponse>> Handle(DeleteExpenseRequest request, CancellationToken cancellationToken)
    {
        var expenseToDelete = _expenses.ById(request.Id);

        if (expenseToDelete == null)
            return Task.FromResult(Result.Fail<ExpenseResponse>(new RecordNotFoundError()));

        _expenses.Delete(expenseToDelete);

        return Task.FromResult(Result.Ok(expenseToDelete.ToExpenseResponse()));
    }
}