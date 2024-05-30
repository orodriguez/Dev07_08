using FluentResults;
using MediatR;

namespace Okane.Application.Expenses;

public class ExpensesService
{
    private readonly IMediator _mediator;

    public ExpensesService(IMediator mediator) => _mediator = mediator;

    public async Task<Response> Create(Create.Request request) => 
        (await TryCreate(request)).Value;

    public Task<Result<Response>> TryCreate(int amount, string category, string description = "") => 
        TryCreate(new Create.Request(amount, category, description));

    public Task<Result<Response>> TryCreate(Create.Request request) => 
        _mediator.Send(request);

    public async Task<Response> Update(Update.Request request) => 
        (await TryUpdate(request)).Value;
    
    public Task<Result<Response>> TryUpdate(Update.Request request) => 
        _mediator.Send(request);

    public async Task<Response> GetById(int id) => 
        (await TryGetById(id)).Value;

    public Task<Result<Response>> TryGetById(int id) => 
        _mediator.Send(new ById.Request(id));

    public async Task<Response> Delete(int id) => 
        (await TryDelete(id)).Value;

    private Task<Result<Response>> TryDelete(int id) => 
        _mediator.Send(new Delete.Request(id));
}