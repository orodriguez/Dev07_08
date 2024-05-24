using FluentValidation;
using Okane.Application.Auth;
using Okane.Application.Categories;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.Create;

public class CreateExpenseHandler
{
    private readonly IValidator<CreateExpenseRequest> _validator;
    private readonly IUserSession _userSession;
    private readonly IExpensesRepository _expensesRepository;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly Func<DateTime> _now;

    public CreateExpenseHandler(IValidator<CreateExpenseRequest> validator,
        IExpensesRepository expensesRepository,
        ICategoriesRepository categoriesRepository,
        IUserSession userSession,
        Func<DateTime> now)
    {
        _validator = validator;
        _expensesRepository = expensesRepository;
        _categoriesRepository = categoriesRepository;
        _userSession = userSession;
        _now = now;
    }

    public ICreateExpenseResponse Handle(CreateExpenseRequest request)
    {
        var validation = _validator.Validate(request);

        var userId = _userSession.GetCurrentUserId();
        
        if (!validation.IsValid)
            return ValidationErrorsResponse.From(validation);

        var category = _categoriesRepository.ByName(request.CategoryName);

        if (category == null)
            return new NotFoundResponse($"Category with Name '{request.CategoryName}' was not found.");
        
        var expense = request.ToExpense(category, _now(), userId);

        _expensesRepository.Add(expense);
        
        return expense.ToExpenseResponse();
    }
}