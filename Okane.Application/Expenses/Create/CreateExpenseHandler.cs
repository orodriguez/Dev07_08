using FluentValidation;
namespace Okane.Application.Expenses.Create;

public class CreateExpenseHandler
{
    private readonly IValidator<CreateExpenseRequest> _validator;
    private readonly IExpensesRepository _expensesRepository;

    public CreateExpenseHandler(IValidator<CreateExpenseRequest> validator, IExpensesRepository expensesRepository)
    {
        _validator = validator;
        _expensesRepository = expensesRepository;
    }

    public IExpenseResponse Handle(CreateExpenseRequest createExpenseRequest)
    {
        var validation = _validator.Validate(createExpenseRequest);

        if (!validation.IsValid)
            return ValidationErrorsExpenseResponse.From(validation);
        
        var expense = createExpenseRequest.ToExpense();

        _expensesRepository.Add(expense);
        
        return expense.ToExpenseResponse();
    }
}