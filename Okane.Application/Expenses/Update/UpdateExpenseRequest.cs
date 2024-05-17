namespace Okane.Application.Expenses.Update;

public record UpdateExpenseRequest(int Amount, string Category, string? Description = null);