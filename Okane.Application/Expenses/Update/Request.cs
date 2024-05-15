namespace Okane.Application.Expenses.Update;

public record Request(int Id, int Amount = 0, string? Category = null, string? Description = null)
{
}