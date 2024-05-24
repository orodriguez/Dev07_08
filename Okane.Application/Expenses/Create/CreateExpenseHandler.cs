using MediatR;

namespace Okane.Application.Expenses.Create;

public class CreateExpenseHandler 
    : IRequestHandler<CreateExpenseRequest, ICreateExpenseResponse>
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
    
    public Task<ICreateExpenseResponse> Handle(CreateExpenseRequest request, CancellationToken cancellationToken)
    {
        var result = _expenseFactory.Create(request);

        if (result is ICreateExpenseResponse response)
            return Task.FromResult<ICreateExpenseResponse>(response);
        
        var expense = ((ExpenseFactoryResponse)result).Value;
        
        _expensesRepository.Add(expense);
        
        return Task.FromResult<ICreateExpenseResponse>(expense.ToExpenseResponse());
    }
}