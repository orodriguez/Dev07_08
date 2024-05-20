using FluentValidation;
using Okane.Application.Categories;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.Create;

public class CreateExpenseHandler
{
    private readonly IValidator<CreateExpenseRequest> _validator;
    private readonly IExpensesRepository _expensesRepository;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly Func<DateTime> _now;

    public CreateExpenseHandler(IValidator<CreateExpenseRequest> validator,
        IExpensesRepository expensesRepository,
        ICategoriesRepository categoriesRepository,
        Func<DateTime> now)
    {
        _validator = validator;
        _expensesRepository = expensesRepository;
        _categoriesRepository = categoriesRepository;
        _now = now;
    }

    public IResponse Handle(CreateExpenseRequest createExpenseRequest)
    {
        var validation = _validator.Validate(createExpenseRequest);

        if (!validation.IsValid)
            return ValidationErrorsResponse.From(validation);

        var category = _categoriesRepository.ByName(createExpenseRequest.CategoryName);

        if (category == null)
            return new NotFoundResponse();
        
        var expense = createExpenseRequest.ToExpense(category, _now());

        _expensesRepository.Add(expense);
        
        return expense.ToExpenseResponse();
    }
}