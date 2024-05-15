namespace Okane.Application.Expenses;
public record Request(int Amount, string Category, string? Description = null);