using FluentResults;
using MediatR;

namespace Okane.Application.Expenses;

public class ExpensesService
{
    private readonly IMediator _mediator;

    public ExpensesService(IMediator mediator) => _mediator = mediator;

    public Task<Result<Response>> Create(int amount, string category, string description) => 
        _mediator.Send(new Create.Request(amount, category, description));
}