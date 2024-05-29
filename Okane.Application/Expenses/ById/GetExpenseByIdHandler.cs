using FluentResults;
using MediatR;
using Okane.Application.Responses;
using Okane.Application.Results;

namespace Okane.Application.Expenses.ById;

public class GetExpenseByIdHandler : IRequestHandler<Request, Result<Response>>
{
    private readonly IExpensesRepository _expensesRepository;

    public GetExpenseByIdHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var expense = _expensesRepository
            .ById(request.Id);

        if (expense == null)
            return Task.FromResult(ErrorResult.RecordNotFound<Response>());
        
        return Task.FromResult(Result.Ok(expense.ToExpenseResponse()));
    }
}