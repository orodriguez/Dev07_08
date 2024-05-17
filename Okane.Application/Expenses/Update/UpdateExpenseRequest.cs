namespace Okane.Application.Expenses.Update;

public record UpdateExpenseRequest(int Amount, string CategoryName, string? Description = null);