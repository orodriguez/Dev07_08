using FluentValidation;
using Okane.Application.Auth;
using Okane.Application.Categories;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;
using Okane.Domain;

namespace Okane.Application.Expenses;

public class ExpenseFactory
{
    private readonly Func<DateTime> _now;
    private readonly IUserSession _session;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IValidator<CreateExpenseRequest> _validator;

    public ExpenseFactory(
        Func<DateTime> now, 
        IUserSession session, 
        ICategoriesRepository categoriesRepository, 
        IValidator<CreateExpenseRequest> validator)
    {
        _now = now;
        _session = session;
        _categoriesRepository = categoriesRepository;
        _validator = validator;
    }

    public IExpenseFactoryResponse Create(CreateExpenseRequest request)
    {
        var validation = _validator.Validate(request);

        if (!validation.IsValid)
            return ValidationErrorsResponse.From(validation);
        
        var category = _categoriesRepository.ByName(request.CategoryName);

        if (category == null)
            return new NotFoundResponse($"Category with Name '{request.CategoryName}' was not found.");
        
        return new ExpenseFactoryResponse(new()
        {
            Amount = request.Amount,
            Category = category,
            Description = request.Description,
            UserId = _session.CurrentUserId,
            CreatedAt = _now()
        });
    }
}