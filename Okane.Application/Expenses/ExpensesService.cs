using MediatR;
using Okane.Application.Expenses.Create;

namespace Okane.Application.Expenses;

public class ExpensesService
{
    private readonly IMediator _mediator;

    public ExpensesService(IMediator mediator) => _mediator = mediator;

    public Task<ICreateExpenseResponse> Create(int amount, string category) => 
        _mediator.Send(new Create.CreateExpenseRequest(amount, category));
}