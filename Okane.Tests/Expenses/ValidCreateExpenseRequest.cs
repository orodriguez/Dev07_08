using Okane.Application.Expenses.Create;

namespace Okane.Tests.Expenses;

// TODO: Replace this with another solution, it does not work with MediatR
public record ValidCreateExpenseRequest() : CreateExpenseRequest(10, "Food", "Pizza");