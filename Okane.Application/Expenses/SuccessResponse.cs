namespace Okane.Application.Expenses;

public record SuccessResponse(int Id, int Amount, string Category, string? Description, DateTime? CreationDate) : IExpenseResponse
{
}