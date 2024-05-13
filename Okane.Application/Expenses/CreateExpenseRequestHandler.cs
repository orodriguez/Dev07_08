namespace Okane.Application.Expenses;

public class CreateExpenseRequestHandler
{
    public ExpenseResponse Handle(CreateExpenseRequest request)
    {
        return new ExpenseResponse(request.Amount, request.Category);
    }
}