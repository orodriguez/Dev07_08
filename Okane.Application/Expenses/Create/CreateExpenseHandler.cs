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

    public ICreateExpenseResponse Handle(CreateExpenseRequest request)
    {
        var validation = _validator.Validate(request);

        if (!validation.IsValid)
            return ValidationErrorsResponse.From(validation);

        var category = _categoriesRepository.ByName(request.CategoryName);

        if (category == null)
            return new NotFoundResponse($"Category with Name '{request.CategoryName}' was not found.");
        
        var expense = request.ToExpense(category, _now());

        _expensesRepository.Add(expense);
        _categoriesRepository.AddExpense(expense);
        
        return expense.ToExpenseResponse();
    }
}