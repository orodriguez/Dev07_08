using FluentResults;
using MediatR;
using Okane.Application.Results;
using Okane.Domain;

namespace Okane.Application.Expenses.Delete;

public class DeleteExpenseHandler : IRequestHandler<Request, Result<Response>>
{
    private readonly IExpensesRepository _expenses;

    public DeleteExpenseHandler(IExpensesRepository expenses) => 
        _expenses = expenses;

    public Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var expenseToDelete = _expenses.ById(request.Id);

        if (expenseToDelete == null)
            return Task.FromResult(ErrorResult.RecordNotFound<Response>());

        _expenses.Delete(expenseToDelete);

        return Task.FromResult(Result.Ok(expenseToDelete.ToExpenseResponse()));
    }
}