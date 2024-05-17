using Okane.Application.Expenses.Create;

namespace Okane.Tests.Expenses;

public record ValidCreateExpenseRequest() : CreateExpenseRequest(10, "Food", "Pizza");