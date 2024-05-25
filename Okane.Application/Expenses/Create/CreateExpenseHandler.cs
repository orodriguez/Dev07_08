using Okane.Application.Responses;

namespace Okane.Application.Expenses.Create;

public class CreateExpenseHandler : IRequestHandler<CreateExpenseRequest, ICreateExpenseResponse>
{
    private readonly ExpenseFactory _expenseFactory;
    private readonly IExpensesRepository _expensesRepository;

    public CreateExpenseHandler(
        ExpenseFactory expenseFactory, 
        IExpensesRepository expensesRepository)
    {
        _expenseFactory = expenseFactory;
        _expensesRepository = expensesRepository;
    }

    public ICreateExpenseResponse Handle(CreateExpenseRequest request)
    {
        var result = _expenseFactory.Create(request);

        if (result is ICreateExpenseResponse response)
            return response;
        
        var expense = ((ExpenseFactoryResponse)result).Value;
        
        _expensesRepository.Add(expense);
        
        return expense.ToExpenseResponse();
    }
}