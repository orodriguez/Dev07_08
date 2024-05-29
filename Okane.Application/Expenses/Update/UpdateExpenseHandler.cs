using FluentResults;
using MediatR;
using Okane.Application.Categories;
using Okane.Application.Responses;
using Okane.Application.Results;

namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler 
    : IRequestHandler<Request, Result<Response>>
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly ICategoriesRepository _categoriesRepository;

    public UpdateExpenseHandler(
        IExpensesRepository expensesRepository, 
        ICategoriesRepository categoriesRepository)
    {
        _expensesRepository = expensesRepository;
        _categoriesRepository = categoriesRepository;
    }

    public Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var category = _categoriesRepository.ByName(request.CategoryName);

        if (category == null)
            throw new NotImplementedException();
        
        var existingExpense = _expensesRepository.ById(request.Id);

        if (existingExpense == null)
            return Task.FromResult(ErrorResult.RecordNotFound<Response>());

        existingExpense.Update(request, category);

        _expensesRepository.Update(existingExpense);
        
        return Task.FromResult(Result.Ok(existingExpense.ToExpenseResponse()));
    }
}