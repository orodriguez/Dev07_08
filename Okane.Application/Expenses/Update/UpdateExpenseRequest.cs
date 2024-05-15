namespace Okane.Application.Expenses.Update;

public record UpdateExpenseRequest(int Id, int Amount, string Category, string? Description = null);