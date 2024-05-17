namespace Okane.Application.Expenses;

public record SuccessResponse(int Id, int Amount, string Category, DateTime CreationDate , string? Description) : IExpenseResponse
{
}