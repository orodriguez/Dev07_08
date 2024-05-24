using MediatR;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.ById;

public class GetExpenseByIdHandler : IRequestHandler<GetExpenseByIdRequest, IGetExpenseByIdResponse>
{
    private readonly IExpensesRepository _expensesRepository;

    public GetExpenseByIdHandler(IExpensesRepository expensesRepository) => 
        _expensesRepository = expensesRepository;

    public Task<IGetExpenseByIdResponse> Handle(GetExpenseByIdRequest request, CancellationToken cancellationToken)
    {
        var expense = _expensesRepository
            .ById(request.Id);

        if (expense == null)
            return Task.FromResult<IGetExpenseByIdResponse>(new NotFoundResponse());
        
        return Task.FromResult<IGetExpenseByIdResponse>(expense.ToExpenseResponse());
    }
}