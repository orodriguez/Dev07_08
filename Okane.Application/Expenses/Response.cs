namespace Okane.Application.Expenses;

public record Response(int Id, int Amount, string Category, string? Description = null);