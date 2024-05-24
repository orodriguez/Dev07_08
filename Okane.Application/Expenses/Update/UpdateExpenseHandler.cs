using MediatR;
using Okane.Application.Categories;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.Update;

public class UpdateExpenseHandler 
    : IRequestHandler<UpdateExpenseRequest, IUpdateExpenseResponse>
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

    public Task<IUpdateExpenseResponse> Handle(UpdateExpenseRequest request, CancellationToken cancellationToken)
    {
        var category = _categoriesRepository.ByName(request.CategoryName);

        if (category == null)
            throw new NotImplementedException();
        
        var existingExpense = _expensesRepository.ById(request.Id);

        if (existingExpense == null)
            return Task.FromResult<IUpdateExpenseResponse>(new NotFoundResponse());

        existingExpense.Update(request, category);

        _expensesRepository.Update(existingExpense);
        
        return Task.FromResult<IUpdateExpenseResponse>(existingExpense.ToExpenseResponse());
    }
}