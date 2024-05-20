namespace Okane.Application.Expenses;

public record ExpensesSuccessResponse(int Id, int Amount, string Category, string? Description) : IExpenseResponse
{
}