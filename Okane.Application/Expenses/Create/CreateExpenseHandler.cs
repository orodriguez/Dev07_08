using FluentValidation;
using Okane.Application.Auth;
using Okane.Application.Categories;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.Create;

public class CreateExpenseHandler
{
    private readonly IValidator<CreateExpenseRequest> _validator;
    private readonly IExpensesRepository _expensesRepository;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly Func<DateTime> _now;
    private readonly IUserSession _session;

    public CreateExpenseHandler(IValidator<CreateExpenseRequest> validator,
        IExpensesRepository expensesRepository,
        ICategoriesRepository categoriesRepository,
        Func<DateTime> now, 
        IUserSession session)
    {
        _validator = validator;
        _expensesRepository = expensesRepository;
        _categoriesRepository = categoriesRepository;
        _now = now;
        _session = session;
    }

    public ICreateExpenseResponse Handle(CreateExpenseRequest request)
    {
        var validation = _validator.Validate(request);

        if (!validation.IsValid)
            return ValidationErrorsResponse.From(validation);

        var category = _categoriesRepository.ByName(request.CategoryName);

        if (category == null)
            return new NotFoundResponse($"Category with Name '{request.CategoryName}' was not found.");
        
        // TODO: Introduce Factory
        var expense = request.ToExpense(category, _now(), _session.CurrentUserId);

        _expensesRepository.Add(expense);
        
        return expense.ToExpenseResponse();
    }
}