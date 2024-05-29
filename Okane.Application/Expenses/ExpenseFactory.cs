using FluentResults;
using FluentValidation;
using Okane.Application.Auth;
using Okane.Application.Categories;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;
using Okane.Application.Results;
using Okane.Domain;

namespace Okane.Application.Expenses;

public class ExpenseFactory
{
    private readonly Func<DateTime> _now;
    private readonly IUserSession _session;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly IValidator<Request> _validator;

    public ExpenseFactory(
        Func<DateTime> now, 
        IUserSession session, 
        ICategoriesRepository categoriesRepository, 
        IValidator<Request> validator)
    {
        _now = now;
        _session = session;
        _categoriesRepository = categoriesRepository;
        _validator = validator;
    }

    public Result<Expense> Create(Request request)
    {
        var validation = _validator.Validate(request);

        if (!validation.IsValid)
            return ErrorResult.From<Expense>(validation);
        
        var category = _categoriesRepository.ByName(request.CategoryName);

        if (category == null)
            return ErrorResult.RecordNotFound<Expense>($"Category with Name '{request.CategoryName}' was not found.");
        
        return new Expense
        {
            Amount = request.Amount,
            Category = category,
            Description = request.Description,
            UserId = _session.CurrentUserId,
            CreatedAt = _now()
        };
    }
}