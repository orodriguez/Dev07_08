namespace Okane.Application.Expenses;

public record SuccessExpenseResponse(int Id, int Amount, string Category, string? Description, DateTime CreatedAt) : IExpenseResponse;